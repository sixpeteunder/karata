﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using Karata.Cards;
using System.Text.Json;

DisplayDeck(deck: Deck.StandardDeck);

var deck1 = Deck.StandardDeck;
var deck2 = Deck.StandardDeck;
deck2.Shuffle();

Console.WriteLine(deck1.SequenceEqual(deck2));
Console.WriteLine(deck1.Aggregate(0, (a, c) => HashCode.Combine(a, c.GetHashCode())));
Console.WriteLine(deck2.Aggregate(0, (a, c) => HashCode.Combine(a, c.GetHashCode())));

StreamReader reader = new("cards.json");
var cardList = JsonSerializer.Deserialize<List<Card>>(await reader.ReadToEndAsync());
Console.WriteLine(cardList[0].Name);

static void DisplayDeck(Deck deck)
{
    var title = $"| {"Card",-20}| {"Rank",-5}|";

    Console.WriteLine($"{deck.Count} cards.\n\n{title}\n{new string('-', title.Length)}");
    foreach (var card in deck) Console.WriteLine($"| {card.Name,-20}| {card.Rank,-5}|");
}