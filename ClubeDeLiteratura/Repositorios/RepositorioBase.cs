    namespace ClubeDeLiteratura.Repositorios;
    using System.Collections.Generic;
    public abstract class RepositorioBase<T>
    {
        protected List<T> listaRegistros = new List<T>();
        protected int contadorId = 1;

        public virtual void Inserir(T registro)
        {
            listaRegistros.Add(registro);
            contadorId++;
        }

        public virtual List<T> SelecionarTodos()
        {
            return new List<T>(listaRegistros);
        }

        public virtual T SelecionarPorID(int Id)
        {
            return listaRegistros.Find(r => ObterId(r) == Id);
        }

        public virtual void Editar(int id, T novoRegistro)
        {
            int indice = listaRegistros.FindIndex(r => ObterId(r) == id);
            if (indice != -1)
            {
                listaRegistros[indice] = novoRegistro;
            }
        }

        public virtual bool Excluir(int id)
        {
            T registro = SelecionarPorID(id);
            if (registro != null)
            {
                listaRegistros.Remove(registro);
                return true;
            }

            return false;
        }


        protected abstract int ObterId(T registro);
    }