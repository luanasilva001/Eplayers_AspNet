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
        public string Email { get; set; }
        public string Senha { get; set; }

        private const string PATH = "Database/Jogador.csv";

        public Jogador()
        {
            CreateFolderAndFile(PATH);
        }

        public string Prepare(Jogador jogador)
        {
            return $"{jogador.IdJogador};{jogador.Nome};{jogador.IdEquipe};{jogador.Email};{jogador.Senha}";
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
                    string [] linha = item.Split(";");

                    Jogador jogador = new Jogador();
                    jogador.IdJogador = int.Parse(linha[0]);
                    jogador.Nome = linha[1];
                    jogador.IdEquipe = int.Parse(linha[2]);
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