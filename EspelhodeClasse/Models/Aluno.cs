using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using Android.Net.Wifi.Aware;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;
using MySql.Data.MySqlClient;
//using static Android.Provider.ContactsContract.CommonDataKinds;

namespace EspelhodeClasse.Models;
internal class Aluno
{
    public string Filename { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }

    public string Username { get; set; }
    public string Password { get; set; }
    public string Status { get; private set; }

    MySqlConnection sqlConn = new MySqlConnection();
//    MySqlCommand sqlCmd = new MySqlCommand();
//    MySqlDataAdapter sqlAdapter = new MySqlDataAdapter();
//    MySqlDataReader sqlDataReader;
//    DataTable dt = new DataTable();
//    DataSet sqlDataset = new DataSet();

//    string sqlQuery;
    string server = "jefbenes.ddns.net";
    string database = "alunos";
    string configFilename = "config.txt";
    string configText;
    public Aluno()
    {
        Username = "userteste";
        Password = "Teste123*";
        Status = "Não Conectado!";

        Filename = $"{Path.GetRandomFileName()}.alunos.txt";
        Text = "";
        Date = DateTime.Now;
    }
    public async Task LoginAsync()
    {
        await SqlConnectionAsync();
    }
    public void LoadConfig()
    {
        LoadConfig1();
    }
    private async Task SqlConnectionAsync()
    {
        var timeout = 5000;

        sqlConn.ConnectionString = $"Server = {server}; Database = {database}; Uid = {Username}; Pwd = {Password};";

        try
        {
            // Use um CancellationTokenSource para criar um CancellationToken com o tempo limite
            var cts = new CancellationTokenSource(timeout);

            await Task.Run(() => sqlConn.Open(), cts.Token);

            Status = "Conectado!";
            configText = $"Username:{Username}\nPassword:{Password}";

            File.WriteAllText(System.IO.Path.Combine(FileSystem.AppDataDirectory, configFilename), configText);
        }
        catch (OperationCanceledException)
        {
            Status = "Tempo limite atingido!";
        }
        catch (MySqlException ex)
        {
            // Lidar com outras exceções específicas do MySQL
            Status = $"Servidor MySql não disponível!{ex.Message}";
        }
        catch (Exception ex)
        {
            // Lidar com outras exceções específicas do MySQL
            Status = $"Não Conectado! Exception: {ex.Message}";
        }
        finally
        {
            if (sqlConn.State == ConnectionState.Open)
            {
                sqlConn.Close();
            }
        }
    }

    private void LoadConfig1()
    {
        string file = System.IO.Path.Combine(FileSystem.AppDataDirectory, configFilename);
        if (File.Exists(file))
        {
            // Lê todas as linhas do arquivo
            string[] lines = File.ReadAllLines(file);

            // Itera sobre cada linha para encontrar os campos desejados
            foreach (string line in lines)
            {
                // Divide a linha pelo caractere de igual
                string[] parts = line.Split(':');

                // Verifica se a linha possui o formato esperado
                if (parts.Length == 2)
                {
                    // Remove espaços em branco antes e depois dos valores
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();

                    // Verifica a chave e atribui o valor correspondente
                    if (key.Equals("Username", StringComparison.OrdinalIgnoreCase))
                    {
                        Username = value;
                    }
                    else if (key.Equals("Password", StringComparison.OrdinalIgnoreCase))
                    {
                        Password = value;
                    }
                }
            }
        }
        else
        {
            Username = "userteste";
            Password = "Teste123*";

            configText = $"Username:{Username}\nPassword:{Password}";

            File.WriteAllText(System.IO.Path.Combine(FileSystem.AppDataDirectory, configFilename), configText);
        }
    }

    public void Save() =>
    File.WriteAllText(System.IO.Path.Combine(FileSystem.AppDataDirectory, Filename), Text);

    public void Delete() =>
        File.Delete(System.IO.Path.Combine(FileSystem.AppDataDirectory, Filename));

    public static Aluno Load(string filename)
    {
        filename = System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);
        if (!File.Exists(filename))
            throw new FileNotFoundException("Arquivo não encontrado.", filename);
        return
            new()
            {
                Filename = Path.GetFileName(filename),
                Text = File.ReadAllText(filename),
                Date = File.GetLastWriteTime(filename)
            };
    }
    public static IEnumerable<Aluno> LoadAll()
    {
        string appDataPath = FileSystem.AppDataDirectory;               // Get the folder where the notes are stored.        
        return Directory                                                // Use Linq extensions to load the *.notes.txt files.
            .EnumerateFiles(appDataPath, "*.alunos.txt")                // Select the file names from the directory                                                       
            .Select(filename => Aluno.Load(Path.GetFileName(filename))) // Each file name is used to load a note                                                                      
            .OrderByDescending(aluno => aluno.Date);                      // With the final collection of notes, order them by date
    }
}
