using App.Domain;
using App.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;

namespace WebApp1.Models
{
    public class AlunoModel
    {
        public List<AlunoModel> listaAlunos()
        {
            //Alunos aluno = new Alunos();
            //aluno.id = 1;
            //aluno.nome = "Fabio";
            //aluno.sobrenome = "Lucci";
            //aluno.telefone = "999809037";
            //aluno.ra = 32210;

            //Alunos aluno1 = new Alunos();
            //aluno1.id = 2;
            //aluno1.nome = "Ana Clara";
            //aluno1.sobrenome = "Lucci";
            //aluno1.telefone = "999809037";
            //aluno1.ra = 12345;

            //List<Alunos> listaAlunos = new List<Alunos>();

            //listaAlunos.Add(aluno);
            //listaAlunos.Add(aluno1);

            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = File.ReadAllText(caminhoArquivo);

            var listaAlunos = JsonConvert.DeserializeObject<List<AlunoModel>>(json);

            //List<string> listaAlunos = new List<string>();
            //listaAlunos.Add("Marta");
            //listaAlunos.Add("Julia");
            //listaAlunos.Add("Paula");
            //listaAlunos.Add("Rafa");
            //listaAlunos.Add("Paulo");

            return listaAlunos;
        }

        public List<AlunoDTO> ListarAluno(int? id = null)
        {
            try
            {
                var alunoDB = new AlunoDAO();
                return alunoDB.ListarAlunoDB(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar alunos: Erro = {ex.Message}");
            }
        }


        //public List<Aluno> ListarAluno()
        //{
        //  var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");
        //
        //  var json = File.ReadAllText(caminhoArquivo);
        //  var listaAlunos = JsonConvert.DeserializeObject<List<Aluno>>(json);
        //
        //    return listaAlunos;
        //}



        //public bool RescreverArquivo(List<AlunoModel> listaAlunos)
        //{
        //  var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");
        //
        //  var json = JsonConvert.SerializeObject(listaAlunos, Formatting.Indented);
        //  File.WriteAllText(caminhoArquivo, json);
        //
        //    return true;
        //}

        public void Inserir(AlunoDTO aluno)
        {
            try
            {
                var alunoDB = new AlunoDAO();
                alunoDB.InserirAlunoDB(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao Inserir aluno: Erro = {ex.Message}");
            }

        }

        public void Atualizar(AlunoDTO aluno)
        {
            try
            {
                var alunoDB = new AlunoDAO();
                alunoDB.AtualizarAlunoDB(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao Atualizar aluno: Erro = {ex.Message}");
            }

        }


        public void Deletar(int id)
        {
            try
            {
                var alunoDB = new AlunoDAO();
                alunoDB.DeletarAlunoDB(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao Deletar aluno: Erro = {ex.Message}");
            }

        }



        //public Aluno Inserir(Aluno Aluno) 
        //{
        //
        //  var listaAlunos = this.ListarAluno();
        //  var maxId = listaAlunos.Max(aluno => aluno.id);
        //  Aluno.id = maxId + 1;
        //  listaAlunos.Add(Aluno);
        //
        //  RescreverArquivo(listaAlunos);
        //    return Aluno;
        //}

        //public Aluno Atualizar(int id, Aluno Aluno)
        //{
        //
        //  var listaAlunos = this.ListarAluno();
        //
        //  var itemIndex = listaAlunos.FindIndex(p => p.id == id);
        //    
        //    if (itemIndex >= 0) 
        //    {
        //      Aluno.id = id;
        //          listaAlunos[itemIndex] = Aluno;
        //      }
        //    else
        //    {
        //        return null;
        //     }
        //
        //  RescreverArquivo(listaAlunos);
        //    return Aluno;
        //}

        //public bool Deletar(int id)
        //{
        //
        //  var listaAlunos = this.ListarAluno();
        //
        //  var itemIndex = listaAlunos.FindIndex(p => p.id == id);
        //
        //    if (itemIndex >= 0)
        //    {
        //      listaAlunos.RemoveAt(itemIndex);
        //      }
        //    else
        //    {
        //       return false;
        //      }
        //
        //      RescreverArquivo(listaAlunos);
        //    return true;
        //}


    }
}