# Clube de Literatura

Projeto desenvolvido em C# para gerenciamento de um Clube de Literatura, com os módulos de Amigos, Caixas, Revistas e Empréstimos.

## Descrição

Este sistema permite o cadastro e controle de empréstimos de revistas literárias, organizadas em caixas, para os amigos participantes do clube. O projeto segue a arquitetura MVC e boas práticas de desenvolvimento, visando organização, reutilização e manutenção facilitada do código.

## Funcionalidades

- Cadastro, edição, exclusão e visualização de **Amigos**.
- Cadastro, edição, exclusão e visualização de **Caixas** que armazenam as revistas.
- Cadastro, edição, exclusão e visualização de **Revistas**.
- Controle de **Empréstimos** das revistas para os amigos, com registro de datas e devoluções.
- Validações para garantir a integridade dos dados (ex.: etiqueta única para caixas).
- Interface de console para interação simples e direta.

## Tecnologias Utilizadas

- Linguagem: C#
- Arquitetura: MVC (Model-View-Controller)
- Estrutura de dados: Collections genéricas (List<T>)
- Persistência: armazenamento em memória (lista)
- Controle de versões: Git/GitHub (repositório privado/público)
  
## Estrutura do Projeto

- **Entidades:** classes que representam os objetos do domínio (Amigo, Caixa, Revista, Empréstimo).
- **Repositórios:** classes responsáveis pela manipulação dos dados em memória.
- **Telas:** classes responsáveis pela interface com o usuário (via console).
- **Program.cs:** ponto de entrada da aplicação, gerencia o fluxo principal.

## Como Executar

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/clube-de-literatura.git
