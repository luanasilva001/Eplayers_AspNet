using System.Collections.Generic;
using System.IO;
using EPlayers_AspNet.Interfaces;
using EPlayers_AspNet.Models;

namespace Eplayers_AspNet_Luaninha.Models
{
    public class Jogador : EPlayersBase, IJogador
    {
        public int IdJogador { get; set; }
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        private const string PATH = "Database/Jogador.csv";

        public Jogador()
        {
            CreateFolderAndFile(PATH);
        }

        public string Prepare(Jogador j)
        {
            return $"{j.IdJogador};{j.IdEquipe};{j.Nome};{j.Email};{j.Senha}";
        }

        public int idJogadores()
        {
            var jogadores = ReadAll();

            if(jogadores.Count == 0)
            {
                return 1;
            }

            var codigo = jogadores[ jogadores.Count - 1].IdJogador;

            codigo ++;

            return codigo;
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
                string[] linha = item.Split(";");

                Jogador jogador = new Jogador();
                jogador.IdJogador = int.Parse(linha[0]);
                jogador.IdEquipe = int.Parse(linha[1]);
                jogador.Nome = linha[2];
                jogador.Email = linha[3];
                jogador.Senha = linha[4];

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