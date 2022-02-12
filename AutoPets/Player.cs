﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AutoPets
{
    public class Player
    {
        readonly Game _game;
        int _lives;
        int _wins;
        readonly Deck _shopDeck;
        readonly Deck _buildDeck;
        Deck _battleDeck;

        public Game Game { get { return _game; } }

        public Deck BuildDeck { get { return _buildDeck; } }

        public Deck BattleDeck { get { return _battleDeck; } }

        public Deck ShopDeck { get { return _shopDeck; } }

        public int Gold { get; set; }

        public int Lives { get { return _lives; } }

        public int Wins { get { return _wins; } }

        public string Name { get; set; }

        public Player(Game game, string name)
        {
            Name = name;
            _game = game;
            _shopDeck = new Deck(this, Game.ShopPetSlots);
            _buildDeck = new Deck(this, Game.BuildDeckSlots);
        }

        public void NewGame()
        {
            _wins = 0;
            _lives = 10;
        }
        public void NewBattle()
        {
            _battleDeck = Deck.Clone(_buildDeck);
        }

        public void BattleCanceled()
        {
            _battleDeck = null;
        }

        public void RoundOver(bool won, bool lost, int round)
        {
            if (won)
                _wins += 1;
            else if (lost)
            {
                if (round == 1 || round == 2)
                    _lives -= 1;
                else if (round == 3 || round == 4)
                    _lives -= 2;
                else
                    _lives -= 3;
                if (_lives < 0)
                    _lives = 0;
            };
        }
    }
}
