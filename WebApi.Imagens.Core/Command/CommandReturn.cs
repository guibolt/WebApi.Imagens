﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Imagens.Core.Command
{
    public class CommandReturn
    {
        public bool Sucesso { get; private set; }
        public string Mensagem { get; private set; }
        public object Erros { get; private set; }
        public dynamic ObjetoRetorno { get; private set; }

        public CommandReturn(bool sucesso)
        {
            Sucesso = sucesso;
        }

        public CommandReturn(bool sucesso, string mensagem) : this(sucesso)
        {
            Mensagem = mensagem;
        }

        public CommandReturn(bool sucesso, object erros, string mensagem) : this(sucesso)
        {
            Erros = erros;
            Mensagem = mensagem;
        }

        public CommandReturn(bool sucesso, string mensagem, dynamic objetoRetorno) : this(sucesso, mensagem)
        {
            ObjetoRetorno = objetoRetorno;
        }
    }
}
