﻿using APIRest.Context;
using APIRest.Models;
using APIRest.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Repositorios
{
    public class RepositorioSiniestros
    {
        private ExpertManagerContext _contexto;

        public RepositorioSiniestros(ExpertManagerContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Siniestro> ObtenerPorId(int id)
        {
            Siniestro siniestro = await _contexto.Siniestros
                                                 .Include(siniestro => siniestro.Aseguradora)
                                                 .Include(siniestro => siniestro.Estado)
                                                 .Include(siniestro => siniestro.UsuarioCreado)
                                                 .Include(siniestro => siniestro.Perito)
                                                 .Include(siniestro => siniestro.Danio)
                                                 .FirstOrDefaultAsync(siniestro => siniestro.Id == id);
            return siniestro;
        }

        public async Task<List<Siniestro>> ObtenerPorIdPerito(int idPerito)
        {
            List<Siniestro> siniestros = await _contexto.Siniestros
                                                        .Include(siniestro => siniestro.Aseguradora)
                                                        .Include(siniestro => siniestro.Estado)
                                                        .Include(siniestro => siniestro.UsuarioCreado)
                                                        .Include(siniestro => siniestro.Perito)
                                                        .Include(siniestro => siniestro.Danio)
                                                        .Where(siniestro => siniestro.Perito.Id == idPerito)
                                                        .ToListAsync();
            return siniestros;
        }

        public async Task<List<Siniestro>> ObtenerTodos()
        {
            List<Siniestro> siniestros = await _contexto.Siniestros
                                                        .Include(siniestro => siniestro.Aseguradora)
                                                        .Include(siniestro => siniestro.Estado)
                                                        .Include(siniestro => siniestro.UsuarioCreado)
                                                        .Include(siniestro => siniestro.Perito)
                                                        .Include(siniestro => siniestro.Danio)
                                                        .ToListAsync();
            return siniestros;
        }

        public async Task<List<Siniestro>> ObtenerPorIdPeritoResponsable(int id)
        {
            // Obtiene los siniestros del perito responsable más los siniestros de los no responsables.

            int idTipoPermiso = (int)TipoPermiso.PeritoNoResponsable;
            List<Siniestro> siniestros = await _contexto.Siniestros
                                                        .Include(siniestro => siniestro.Aseguradora)
                                                        .Include(siniestro => siniestro.Estado)
                                                        .Include(siniestro => siniestro.UsuarioCreado)
                                                        .Include(siniestro => siniestro.Perito)
                                                        .Include(siniestro => siniestro.Perito.Permiso)
                                                        .Include(siniestro => siniestro.Danio)
                                                        .Where(siniestro => siniestro.Perito.Id == id || siniestro.Perito.Permiso.Id == idTipoPermiso)
                                                        .ToListAsync();
            return siniestros;
        }

        public async Task Actualizar(Siniestro siniestro)
        {
            try
            {
                _contexto.Update(siniestro);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public async Task Guardar(Siniestro siniestro)
        {
            try
            {
                _contexto.Add(siniestro);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task Eliminar(Siniestro siniestro)
        {
            try
            {
                _contexto.Remove(siniestro);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EsValido(SiniestroVm siniestroVm)
        {
            if (siniestroVm.IdAseguradora <= 0)
                throw new Exception("La aseguradora seleccionada no es válida");

            if (siniestroVm.IdUsuarioAlta <= 0)
                throw new Exception("El usuario de alta no es válido");

            List<int> idsSujetoAfectado = Enum.GetValues(typeof(SujetoAfectado)).Cast<int>()
                                                                                .ToList();

            bool existeIdSujetoAfectado = Array.Exists(idsSujetoAfectado.ToArray(), id => id == siniestroVm.IdSujetoAfectado);

            if (!existeIdSujetoAfectado)
                throw new Exception("El sujeto afectado seleccionado no es válido");

            if (siniestroVm.IdPerito <= 0)
                throw new Exception("El perito seleccionado no es válido");

            if (siniestroVm.IdDanio <= 0)
                throw new Exception("El daño seleccionado no es válido");

            if (siniestroVm.Direccion is null || siniestroVm.Direccion.Length == 0)
                throw new Exception("La dirección está vacía");

            if (siniestroVm.Descripcion is null || siniestroVm.Descripcion.Length == 0)
                throw new Exception("La descripción está vacía");

            return true;
        }
    }
}
