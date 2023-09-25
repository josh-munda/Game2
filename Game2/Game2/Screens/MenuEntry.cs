using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Game2.StateManagement;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Screens
{
    // Helper class for StartScreen. This will draw the entry text string, but can be
    // customized to display menu entries such as start game and exit game. This also
    // provides an event handler that handles when a selection has been made
    public class MenuEntry
    {
        private string _text;
        private float _selection;
        //private Vector2 _position;

        public string Text
        {
            private get => _text;
            set => _text = value;
        }

        /*
        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }
        */

        //public event EventHandler<PlayerIndexEventArgs> Selected;

        //protected internal virtual void OnSelectedEntry(PlayerIndex playerIndex)
        //{
            //Selected?.Invoke(this, new PlayerIndexEventArgs(playerIndex));
        //}
    }
}
