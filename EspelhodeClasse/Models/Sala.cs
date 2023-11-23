using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EspelhodeClasse.Models;
internal class Sala : ObservableObject
{
    private int colunas;
    private int linhas;
    private int maxColunas = 10;
    private int maxLinhas = 10;

    public int Colunas
    {
        get { return colunas; }
        set
        {
            if (colunas != value)
            {
                colunas = value;
            }
        }
    }
    public int Linhas
    {
        get { return linhas; }
        set
        {
            if (linhas != value)
            {
                linhas = value;
            }
        }
    }

    public Sala()
    {
        Colunas = 1;
        Linhas = 1;
    }
    public void MaisColunas()
    {
        if (Colunas < maxColunas) Colunas++;
    }
    public void MenosColunas()
    {
        if (Colunas > 1) Colunas--;
    }
    public void MaisLinhas()
    {
        if (Linhas < maxLinhas) Linhas++;
    }
    public void MenosLinhas()
    {
        if (Linhas > 1) Linhas--;
    }
}
