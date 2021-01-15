using System.Collections.Generic;
using System.IO;
using EPlayers_AspNet.Interfaces;

namespace EPlayers_AspNet.Models
{
    public class Jogador : EPlayersBase , IJogador
    {
        public int IdJogador { get; set; }
        public string Nome { get; set; }
        public int IdEquipe { get; set; }

        private const string PATH = "Database/Jogador.csv";

        public Jogador()
        {
            CreateFolderAndFile(PATH);
        }

        public string Prepare(Jogador jogador)
        {
            return $"{jogador.IdJogador};{jogador.Nome};{jogador.IdEquipe}";
        }

        public void Create(Jogador jogador)
        {
            string[] linhas = {Prepare(jogador)};
            File.AppendAllLines(PATH, linhas);
        }

        public List<Jogador> ReadAll()
        {
            List<Jogador> jogadores = new List<Jogador>();
            string[] linhas = File.ReadAllLines(PATH);
            
            foreach (var item in linhas)
            {
                string [] linha = item.Split(";");

                Jogador jogador = new Jogador();
                jogador.IdJogador = int.Parse(linha[0]);
                jogador.Nome = linha[1];
                jogador.IdEquipe = int.Parse(linha[2]);

                jogadores.Add(jogador);
            }

                return jogadores;
        }

        public void Update(Jogador jogador)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == jogador.IdJogador.ToString());
            linhas.Add(Prepare(jogador));
            RewriteCSV(PATH, linhas);
        }

        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            RewriteCSV(PATH, linhas);
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Delete()
        {
            throw new System.NotImplementedException();
        }
    }
}