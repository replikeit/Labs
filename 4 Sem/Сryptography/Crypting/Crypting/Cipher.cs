using System.
    
    Collections.Generic;

namespace Crypting
{
    abstract class Cipher
    {
        protected static readonly Dictionary<char, double> statisticAlphabet = new Dictionary<char, double>()
        {
            {'e', 12.7 },
            {'t', 9.06 },
            {'a', 8.17 },
            {'o', 7.51 },
            {'i', 6.97 },
            {'n', 6.75 },
            {'s', 6.33 },
            {'h', 6.09 },
            {'r', 5.99 },
            {'d', 4.25 },
            {'l', 4.03 },
            {'c', 2.78 },
            {'u', 2.76 },
            {'m', 2.41 },
            {'w', 2.36 },
            {'f', 2.36 },
            {'g', 2.02 },
            {'y', 1.97 },
            {'p', 1.93 },
            {'b', 1.49 },
            {'v', 0.98 },
            {'k', 0.77 },
            {'x', 0.15 },
            {'j', 0.15 },
            {'q', 0.1 },
            {'z', 0.05 },
        };
        protected static readonly Dictionary<string, double> empThreegramStatistic = new Dictionary<string, double>()
        {
            {"the", 1.87 },
            {"and", 0.78 },
            {"ing", 0.69 },
            {"her", 0.42 },
            {"tha", 0.37 },
            {"ent", 0.36 },
            {"ere", 0.33 },
            {"ion", 0.33 },
            {"eth", 0.32 },
            {"nth", 0.32 },
            {"hat", 0.31 },
            {"int", 0.29 },
            {"sth", 0.26 },
            {"ter", 0.26 },
            {"est", 0.26 },
            {"tio", 0.26 },
            {"his", 0.25 },
            {"oft", 0.24 },
            {"hes", 0.24 },
            {"ith", 0.24 },
            {"ers", 0.24 },
            {"oth", 0.23 },
            {"fth", 0.23 },
            {"dth", 0.23 },
            {"ver", 0.22 },
            {"tth", 0.22 },
            {"thi", 0.22 },
            {"rea", 0.21 },
            {"san", 0.21 },
            {"wit", 0.21 },
            {"ate", 0.2 },
            {"ear", 0.19 },
        };
        public abstract string EnCrypt(string str);
        public abstract string DeCrypt(string str);


        protected static Dictionary<string, double> GetThreegramStatDictionary()
        {
            return new Dictionary<string, double>()
            {
                {"the", 0 },
                {"and", 0 },
                {"ing", 0 },
                {"her", 0 },
                {"tha", 0 },
                {"ent", 0 },
                {"ere", 0 },
                {"ion", 0 },
                {"eth", 0 },
                {"nth", 0 },
                {"hat", 0 },
                {"int", 0 },
                {"sth", 0 },
                {"ter", 0 },
                {"est", 0 },
                {"tio", 0 },
                {"his", 0 },
                {"oft", 0 },
                {"hes", 0 },
                {"ith", 0 },
                {"ers", 0 },
                {"oth", 0 },
                {"fth", 0 },
                {"dth", 0 },
                {"ver", 0 },
                {"tth", 0 },
                {"thi", 0 },
                {"rea", 0 },
                {"san", 0 },
                {"wit", 0 },
                {"ate", 0 },
                {"ear", 0 },
            };

        }

        protected static Dictionary<char, double> GetStatDictionary()
        {
            return new Dictionary<char, double>()
            {
                {'e', 0 },
                {'t', 0 },
                {'a', 0 },
                {'o', 0 },
                {'i', 0 },
                {'n', 0 },
                {'s', 0 },
                {'h', 0 },
                {'r', 0 },
                {'d', 0 },
                {'l', 0 },
                {'c', 0 },
                {'u', 0 },
                {'m', 0 },
                {'w', 0 },
                {'f', 0 },
                {'g', 0 },
                {'y', 0 },
                {'p', 0 },
                {'b', 0 },
                {'v', 0 },
                {'k', 0 },
                {'x', 0 },
                {'j', 0 },
                {'q', 0 },
                {'z', 0 },
            };
        }
    }
}
