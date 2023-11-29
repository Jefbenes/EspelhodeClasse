using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Maui.Storage;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EspelhodeClasse.Models;
internal class Sala
{
    readonly private string configFilename = "config.txt";
    readonly private int _maxColunas = 3;
    readonly private int _maxLinhas = 3;
    private string configTxt;
    private string colunaTxt;
    private int _colunas;
    private int _linhas;
    bool[] _mesaCorredor;

    public bool GetMesaCorredor(int i)
    {
        if (i >= 0 && i < _mesaCorredor.Length)
        {
            return _mesaCorredor[i];
        }
        else return false;
    }    
    public void SetMesaCorredor(int i, bool value)
    {
        if (i >= 0 && i < _mesaCorredor.Length)
        {
            if (_mesaCorredor[i] != value)
            {
                _mesaCorredor[i] = value;
                SaveConfig();
            }
        }
    }
    public int MaxColunas
    {
        get { return _maxColunas; }
    }
    public int MaxLinhas
    {
        get { return _maxLinhas; }
    }
    public int Colunas
    {
        get { return _colunas; }
        set
        {
            if (_colunas != value)
            {
                _colunas = value;
            }
        }
    }
    public int Linhas
    {
        get { return _linhas; }
        set
        {
            if (_linhas != value)
            {
                _linhas = value;
            }
        }
    }
    public void MaisColunas()
    {
        if (Colunas < MaxColunas) Colunas++;
        SaveConfig();
    }
    public void MenosColunas()
    {
        if (Colunas > 1) Colunas--;
        SaveConfig();
    }
    public void MaisLinhas()
    {
        if (Linhas < MaxLinhas) Linhas++;
        SaveConfig();
    }
    public void MenosLinhas()
    {
        if (Linhas > 1) Linhas--;
        SaveConfig();
    }
    public void LoadConfig()
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
                    if (key.Equals("Colunas", StringComparison.OrdinalIgnoreCase))
                    {
                        if (int.TryParse(value, out int colunas))
                        {
                            Colunas = colunas;
                        }
                        else
                        {
                            Colunas = 1;
                        }
                    }
                    else if (key.Equals("Linhas", StringComparison.OrdinalIgnoreCase))
                    {
                        if (int.TryParse(value, out int linhas))
                        {
                            Linhas = linhas;
                        }
                        else
                        {
                            Linhas = 1;
                        }
                    }
                }
                else
                // Verifica se a linha possui o formato esperado
                if (parts.Length == 3)
                {
                    // Remove espaços em branco antes e depois dos valores
                    string key = parts[0].Trim();
                    string col = parts[1].Trim();
                    string val = parts[2].Trim();

                    // Verifica a chave e atribui o valor correspondente
                    if (key.Equals("Coluna", StringComparison.OrdinalIgnoreCase))
                    {
                        if (int.TryParse(col, out int colunas))
                        {
                            if(colunas<MaxColunas)
                            {
                                if (val == "M")
                                {
                                    SetMesaCorredor(colunas, true);
                                }
                                else
                                {
                                    SetMesaCorredor(colunas, false);
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {
            SaveConfig();
        }
    }
    public void SaveConfig()
    {
        configTxt = $"Colunas:{Colunas}\nLinhas:{Linhas}\n";
        File.WriteAllText(System.IO.Path.Combine(FileSystem.AppDataDirectory, configFilename), configTxt);
        for (int i = 0; i < MaxColunas; i++)
        {
            if (GetMesaCorredor(i))
            {
                colunaTxt = $"Coluna:{i}:M";
            }
            else
            {
                colunaTxt = $"Coluna:{i}:C";
            }

            File.AppendAllText(System.IO.Path.Combine(FileSystem.AppDataDirectory, configFilename), colunaTxt + "\n");
        };
    }
    public Sala()
    {
        Colunas = 1;
        Linhas = 1;
        InitSala();
        LoadConfig();
    }
    private void InitSala()
    {
        _mesaCorredor = new bool[MaxColunas];

        for (int i = 0; i < MaxColunas; i++)
        {
            _mesaCorredor[i] = true;
        }
    }
}
