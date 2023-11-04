using Exiled.API.Features;

using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;
using Button = InteractiveButtons.API.Events.Handlers.Button;

using Exiled.API.Features.Pickups;
using System.Collections.Generic;
using InteractiveButtons.API.Events.Handlers;
using InteractiveButtons.API.Events.EventArgs;

namespace ExamplePluginInteractiveButton
{
    public sealed class Plugin : Plugin<Config>
    {
        public override string Author => "InteractDev (KadotCom)";

        public override string Name => "ExamplePlugin-InteractiveButton";

        public override string Prefix => Name;

        public static Plugin Instance;

        private EventHandlers _handlers;

        public override void OnEnabled()
        {
            Instance = this;

            
            RegisterEvents();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();

            Instance = null;

            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            _handlers = new EventHandlers();

            Server.RoundStarted += _handlers.OnRoundStart;
            Button.ButtonInteracted += _handlers.ButtonInteracted;
            Button.ButtonCreated += _handlers.ButtonCreated;
        }

        private void UnregisterEvents()
        {
            Server.RoundStarted -= _handlers.OnRoundStart;
            Button.ButtonInteracted -= _handlers.ButtonInteracted;
            Button.ButtonCreated -= _handlers.ButtonCreated;

            _handlers = null;
        }
    }
}