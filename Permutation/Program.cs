//Given 2 strings, write a method to decide if one is a permutation of the other.
// Explanation, if 2 words have the same letters in same quantity, its an permutation bcs its an anagram.
using System.Collections.Generic;

bool IsPerumtedQuadratique(string word1, string word2)
{
    var word1List = CountNumbersOfLetters(word1);

    var word2List = CountNumbersOfLetters(word2);

    var verifyWord = 0;

    if (word1List.Count != word2List.Count)
        return false;
    else
    {
        foreach (var word in word1List)
        {
            for (int i = 0; i < word2List.Count; i++)
            {
                if (word.Equals(word2List[i]))
                    verifyWord++;
            }

            Console.WriteLine($"{word.Letter}, {word.NbLetters}");
        }

        if (verifyWord == word1List.Count)
            return true;
        else return false;
    }
}

List<int> Tri(List<int> numbers)
{
    for (int i = numbers.Count - 1; i >= 1; i--)
    {
        for (int j = 1; j <= i; j++)
        {
            if (numbers[j - 1] > numbers[j])
            {
                int temp = numbers[j - 1];
                numbers[j - 1] = numbers[j];
                numbers[j] = temp;
            }
        }   
    }
        
    return numbers;
}

List<int> numbers = new List<int>() { 1, 20, 12, 17, 55, 9 };

numbers.ForEach(x => Console.Write($"{x}-"));

var n = Tri(numbers);

Console.WriteLine();

n.ForEach(x => Console.Write($"{x}-"));

void IsPermutedLogarithmique(string word1, string word2)
{
    var alphabet = new Dictionary<int, string>();

    for (char c = 'A'; c <= 'Z'; c++)
    {
        int key = c - 'A' + 1;
        alphabet.Add(key, c.ToString().ToLower());
    }

    var word1Alphabet = "";

    for(int i = 1; i < alphabet.Count; i++)
    {
        for(int j = 0; j < word1.Length; j++)
        {
            if (alphabet[i] == word1[j].ToString())
                word1Alphabet += word1[j];
        }
    }
    Console.WriteLine(word1Alphabet);
}

//IsPermutedLogarithmique("tttsavb", "word2");

static string SortString(string input)
{
    char[] chars = input.ToCharArray();

    Array.Sort(chars);

    return new string(chars);
}


List<Word> CountNumbersOfLetters(string word)
{
    var numbers = new List<Word>();

    foreach(var letter in word)
    {
        if (!numbers.Any(x => x.Letter == letter.ToString()))
        {
            numbers.Add(new Word(letter.ToString(), 1));
        }
        else
        {
            var nb = numbers.Where(x => x.Letter == letter.ToString()).Single();

            nb.NbLetters++;
        }
    }

    return numbers;
}

//Console.WriteLine(IsPermutedLogarithmique("couu", "ccou"));
public class Word
{
    public string Letter { get; set; }
    public int NbLetters { get; set; }

    public Word(string letter, int nbLetters)
    {
        Letter = letter;
        NbLetters = nbLetters;
    }

    public override bool Equals(object? obj)
    {
        Word p = (Word)obj;

        return (Letter == p.Letter) && (NbLetters == p.NbLetters);
    }
}
