﻿// See https://aka.ms/new-console-template for more information

public class Player
{
    public string Name { get; set; }
    public int Position { get; set; }
    public int Score { get; set; }

    public Player(string name)
    {
        Name = name;
        Position = 0; 
        Score = 0;    
    }


    public void Move(int steps)
    {
        Position += steps;
    }


    public void UpdateScore(int points)
    {
        Score += points;
    }
}
public class Board
{
    public int Size { get; set; }
    public Dictionary<int, int> Rewards { get; set; }

    public Board(int size)
    {
        Size = size;
        Rewards = new Dictionary<int, int>();
        GenerateRewards();
    }


    private void GenerateRewards()
    {
        Random rand = new Random();
        for (int i = 1; i < Size; i++)
        {

            if (rand.NextDouble() < 0.3)
            {
                Rewards[i] = rand.Next(1, 11);
            }
        }
    }

    public int GetReward(int position)
    {
        return Rewards.ContainsKey(position) ? Rewards[position] : 0;
    }
}
public interface IPlayer
{
    string Name { get; set; }
    int Position { get; set; }
    int Score { get; set; }

    void Move(int steps);
    void UpdateScore(int points);
}
public class Warrior : IPlayer
{
    public string Name { get; set; }
    public int Position { get; set; }
    public int Score { get; set; }

    public Warrior(string name)
    {
        Name = name;
        Position = 0;
        Score = 0;
    }

    public void Move(int steps)
    {
        Position += steps;
    }

    public void UpdateScore(int points)
    {
        Score += points * 2;
    }
}
public class Mage : IPlayer
{
    public string Name { get; set; }
    public int Position { get; set; }
    public int Score { get; set; }

    public Mage(string name)
    {
        Name = name;
        Position = 0;
        Score = 0;
    }

    public void Move(int steps)
    {
        Position += steps;
    }

    public void UpdateScore(int points)
    {
        Score += points;
    }

    public void CastSpell(Board board, Player target)
    {

        target.Position += 3;
    }
}
public class Healer : IPlayer
{
    public string Name { get; set; }
    public int Position { get; set; }
    public int Score { get; set; }

    public Healer(string name)
    {
        Name = name;
        Position = 0;
        Score = 0;
    }

    public void Move(int steps)
    {
        Position += steps;
    }

    public void UpdateScore(int points)
    {
        Score += points;
    }

    public void Heal(Player target)
    {
        
        target.UpdateScore(5);
    }
}
