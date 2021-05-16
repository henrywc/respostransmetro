﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BlackSys
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class oracleconnectContainer : DbContext
    {
        public oracleconnectContainer()
            : base("name=oracleconnectContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual int ACTUALIZA_COSTOSBODEGA()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ACTUALIZA_COSTOSBODEGA");
        }
    
        public virtual int ACTUALIZA_DETALLE_BODEGA(Nullable<decimal> p_PROYECTO, Nullable<decimal> p_BODEGA)
        {
            var p_PROYECTOParameter = p_PROYECTO.HasValue ?
                new ObjectParameter("P_PROYECTO", p_PROYECTO) :
                new ObjectParameter("P_PROYECTO", typeof(decimal));
    
            var p_BODEGAParameter = p_BODEGA.HasValue ?
                new ObjectParameter("P_BODEGA", p_BODEGA) :
                new ObjectParameter("P_BODEGA", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ACTUALIZA_DETALLE_BODEGA", p_PROYECTOParameter, p_BODEGAParameter);
        }
    
        public virtual int ACTUALIZA_ORDEN_WEB(Nullable<decimal> pR_PROYECTO, Nullable<decimal> pR_ORDEN)
        {
            var pR_PROYECTOParameter = pR_PROYECTO.HasValue ?
                new ObjectParameter("PR_PROYECTO", pR_PROYECTO) :
                new ObjectParameter("PR_PROYECTO", typeof(decimal));
    
            var pR_ORDENParameter = pR_ORDEN.HasValue ?
                new ObjectParameter("PR_ORDEN", pR_ORDEN) :
                new ObjectParameter("PR_ORDEN", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ACTUALIZA_ORDEN_WEB", pR_PROYECTOParameter, pR_ORDENParameter);
        }
    
        public virtual int ACTUALIZA_PEDIDO_WEB(Nullable<decimal> pR_PROYECTO, Nullable<decimal> pR_ORDEN)
        {
            var pR_PROYECTOParameter = pR_PROYECTO.HasValue ?
                new ObjectParameter("PR_PROYECTO", pR_PROYECTO) :
                new ObjectParameter("PR_PROYECTO", typeof(decimal));
    
            var pR_ORDENParameter = pR_ORDEN.HasValue ?
                new ObjectParameter("PR_ORDEN", pR_ORDEN) :
                new ObjectParameter("PR_ORDEN", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ACTUALIZA_PEDIDO_WEB", pR_PROYECTOParameter, pR_ORDENParameter);
        }
    
        public virtual int ACTUALIZA_PRE_REQUISICION(Nullable<decimal> pR_PROYECTO, Nullable<decimal> pR_BODEGA, Nullable<decimal> pR_MODELO, Nullable<decimal> pR_OBRA)
        {
            var pR_PROYECTOParameter = pR_PROYECTO.HasValue ?
                new ObjectParameter("PR_PROYECTO", pR_PROYECTO) :
                new ObjectParameter("PR_PROYECTO", typeof(decimal));
    
            var pR_BODEGAParameter = pR_BODEGA.HasValue ?
                new ObjectParameter("PR_BODEGA", pR_BODEGA) :
                new ObjectParameter("PR_BODEGA", typeof(decimal));
    
            var pR_MODELOParameter = pR_MODELO.HasValue ?
                new ObjectParameter("PR_MODELO", pR_MODELO) :
                new ObjectParameter("PR_MODELO", typeof(decimal));
    
            var pR_OBRAParameter = pR_OBRA.HasValue ?
                new ObjectParameter("PR_OBRA", pR_OBRA) :
                new ObjectParameter("PR_OBRA", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ACTUALIZA_PRE_REQUISICION", pR_PROYECTOParameter, pR_BODEGAParameter, pR_MODELOParameter, pR_OBRAParameter);
        }
    
        public virtual int ACTUALIZA_TAREA()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ACTUALIZA_TAREA");
        }
    
        public virtual int AGREGA_ADICIONAL_EMPLEADO()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AGREGA_ADICIONAL_EMPLEADO");
        }
    
        public virtual int AUTORIZA_BITACORA_DETALLE()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AUTORIZA_BITACORA_DETALLE");
        }
    
        public virtual int AUTORIZA_PRECIO_MO()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AUTORIZA_PRECIO_MO");
        }
    
        public virtual int AUTORIZA_PRECIOS_BITACORA()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AUTORIZA_PRECIOS_BITACORA");
        }
    
        public virtual int AUT_PRECIOS_BITACORA_ORDEN()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AUT_PRECIOS_BITACORA_ORDEN");
        }
    
        public virtual int BORRA_DET_PREREQ()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("BORRA_DET_PREREQ");
        }
    
        public virtual int CALCULA_ASIENTO_CUENTA()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CALCULA_ASIENTO_CUENTA");
        }
    
        public virtual int CALCULA_SALARIO_CUADRILLA(Nullable<decimal> p_CUADRILLA, Nullable<decimal> p_TRABAJO)
        {
            var p_CUADRILLAParameter = p_CUADRILLA.HasValue ?
                new ObjectParameter("P_CUADRILLA", p_CUADRILLA) :
                new ObjectParameter("P_CUADRILLA", typeof(decimal));
    
            var p_TRABAJOParameter = p_TRABAJO.HasValue ?
                new ObjectParameter("P_TRABAJO", p_TRABAJO) :
                new ObjectParameter("P_TRABAJO", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CALCULA_SALARIO_CUADRILLA", p_CUADRILLAParameter, p_TRABAJOParameter);
        }
    
        public virtual int CALCULA_SALARIO_CUADRILLA_KJGH(Nullable<decimal> p_CUADRILLA, Nullable<decimal> p_TRABAJO)
        {
            var p_CUADRILLAParameter = p_CUADRILLA.HasValue ?
                new ObjectParameter("P_CUADRILLA", p_CUADRILLA) :
                new ObjectParameter("P_CUADRILLA", typeof(decimal));
    
            var p_TRABAJOParameter = p_TRABAJO.HasValue ?
                new ObjectParameter("P_TRABAJO", p_TRABAJO) :
                new ObjectParameter("P_TRABAJO", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CALCULA_SALARIO_CUADRILLA_KJGH", p_CUADRILLAParameter, p_TRABAJOParameter);
        }
    
        public virtual int COPIA_FORMULAS(Nullable<decimal> pFORMULA_ANTERIOR, Nullable<decimal> pFORMULA_NUEVA)
        {
            var pFORMULA_ANTERIORParameter = pFORMULA_ANTERIOR.HasValue ?
                new ObjectParameter("PFORMULA_ANTERIOR", pFORMULA_ANTERIOR) :
                new ObjectParameter("PFORMULA_ANTERIOR", typeof(decimal));
    
            var pFORMULA_NUEVAParameter = pFORMULA_NUEVA.HasValue ?
                new ObjectParameter("PFORMULA_NUEVA", pFORMULA_NUEVA) :
                new ObjectParameter("PFORMULA_NUEVA", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("COPIA_FORMULAS", pFORMULA_ANTERIORParameter, pFORMULA_NUEVAParameter);
        }
    
        public virtual int COPIAS_FABRICA(Nullable<decimal> p_PROYECTO, Nullable<decimal> p_BODEGA, Nullable<decimal> p_LOTE, Nullable<decimal> p_MODELO, Nullable<decimal> p_ACTIVIDAD, Nullable<decimal> p_TAREA, Nullable<decimal> p_COPIAS)
        {
            var p_PROYECTOParameter = p_PROYECTO.HasValue ?
                new ObjectParameter("P_PROYECTO", p_PROYECTO) :
                new ObjectParameter("P_PROYECTO", typeof(decimal));
    
            var p_BODEGAParameter = p_BODEGA.HasValue ?
                new ObjectParameter("P_BODEGA", p_BODEGA) :
                new ObjectParameter("P_BODEGA", typeof(decimal));
    
            var p_LOTEParameter = p_LOTE.HasValue ?
                new ObjectParameter("P_LOTE", p_LOTE) :
                new ObjectParameter("P_LOTE", typeof(decimal));
    
            var p_MODELOParameter = p_MODELO.HasValue ?
                new ObjectParameter("P_MODELO", p_MODELO) :
                new ObjectParameter("P_MODELO", typeof(decimal));
    
            var p_ACTIVIDADParameter = p_ACTIVIDAD.HasValue ?
                new ObjectParameter("P_ACTIVIDAD", p_ACTIVIDAD) :
                new ObjectParameter("P_ACTIVIDAD", typeof(decimal));
    
            var p_TAREAParameter = p_TAREA.HasValue ?
                new ObjectParameter("P_TAREA", p_TAREA) :
                new ObjectParameter("P_TAREA", typeof(decimal));
    
            var p_COPIASParameter = p_COPIAS.HasValue ?
                new ObjectParameter("P_COPIAS", p_COPIAS) :
                new ObjectParameter("P_COPIAS", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("COPIAS_FABRICA", p_PROYECTOParameter, p_BODEGAParameter, p_LOTEParameter, p_MODELOParameter, p_ACTIVIDADParameter, p_TAREAParameter, p_COPIASParameter);
        }
    
        public virtual int DESMARCA_METAS()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DESMARCA_METAS");
        }
    
        public virtual int ENVIA_CORREO(string p_DIR_DESTINO, string p_ASUNTO, string p_MENSAJE)
        {
            var p_DIR_DESTINOParameter = p_DIR_DESTINO != null ?
                new ObjectParameter("P_DIR_DESTINO", p_DIR_DESTINO) :
                new ObjectParameter("P_DIR_DESTINO", typeof(string));
    
            var p_ASUNTOParameter = p_ASUNTO != null ?
                new ObjectParameter("P_ASUNTO", p_ASUNTO) :
                new ObjectParameter("P_ASUNTO", typeof(string));
    
            var p_MENSAJEParameter = p_MENSAJE != null ?
                new ObjectParameter("P_MENSAJE", p_MENSAJE) :
                new ObjectParameter("P_MENSAJE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ENVIA_CORREO", p_DIR_DESTINOParameter, p_ASUNTOParameter, p_MENSAJEParameter);
        }
    
        public virtual int GENERA_COMMIT()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GENERA_COMMIT");
        }
    
        public virtual int GENERA_DETALLE_LOTE_TAREA()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GENERA_DETALLE_LOTE_TAREA");
        }
    
        public virtual int GENERA_DEVOLUCION(Nullable<decimal> pSOLICITUD)
        {
            var pSOLICITUDParameter = pSOLICITUD.HasValue ?
                new ObjectParameter("PSOLICITUD", pSOLICITUD) :
                new ObjectParameter("PSOLICITUD", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GENERA_DEVOLUCION", pSOLICITUDParameter);
        }
    
        public virtual int GENERA_PEDIDO(Nullable<decimal> p_PRE_PEDIDO, Nullable<decimal> p_PROYECTO, Nullable<decimal> p_IDEXPLOSION)
        {
            var p_PRE_PEDIDOParameter = p_PRE_PEDIDO.HasValue ?
                new ObjectParameter("P_PRE_PEDIDO", p_PRE_PEDIDO) :
                new ObjectParameter("P_PRE_PEDIDO", typeof(decimal));
    
            var p_PROYECTOParameter = p_PROYECTO.HasValue ?
                new ObjectParameter("P_PROYECTO", p_PROYECTO) :
                new ObjectParameter("P_PROYECTO", typeof(decimal));
    
            var p_IDEXPLOSIONParameter = p_IDEXPLOSION.HasValue ?
                new ObjectParameter("P_IDEXPLOSION", p_IDEXPLOSION) :
                new ObjectParameter("P_IDEXPLOSION", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GENERA_PEDIDO", p_PRE_PEDIDOParameter, p_PROYECTOParameter, p_IDEXPLOSIONParameter);
        }
    
        public virtual int GENERA_PLAN_CONSUMO(Nullable<decimal> p_PROYECTO, Nullable<decimal> p_MODELO, Nullable<decimal> p_ACTIVIDAD, Nullable<decimal> p_TAREA, Nullable<decimal> p_BODEGA)
        {
            var p_PROYECTOParameter = p_PROYECTO.HasValue ?
                new ObjectParameter("P_PROYECTO", p_PROYECTO) :
                new ObjectParameter("P_PROYECTO", typeof(decimal));
    
            var p_MODELOParameter = p_MODELO.HasValue ?
                new ObjectParameter("P_MODELO", p_MODELO) :
                new ObjectParameter("P_MODELO", typeof(decimal));
    
            var p_ACTIVIDADParameter = p_ACTIVIDAD.HasValue ?
                new ObjectParameter("P_ACTIVIDAD", p_ACTIVIDAD) :
                new ObjectParameter("P_ACTIVIDAD", typeof(decimal));
    
            var p_TAREAParameter = p_TAREA.HasValue ?
                new ObjectParameter("P_TAREA", p_TAREA) :
                new ObjectParameter("P_TAREA", typeof(decimal));
    
            var p_BODEGAParameter = p_BODEGA.HasValue ?
                new ObjectParameter("P_BODEGA", p_BODEGA) :
                new ObjectParameter("P_BODEGA", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GENERA_PLAN_CONSUMO", p_PROYECTOParameter, p_MODELOParameter, p_ACTIVIDADParameter, p_TAREAParameter, p_BODEGAParameter);
        }
    
        public virtual int GENERA_PLANILLA(Nullable<decimal> pSOLICITUD, Nullable<decimal> pCUADRILLA, string pESTADO)
        {
            var pSOLICITUDParameter = pSOLICITUD.HasValue ?
                new ObjectParameter("PSOLICITUD", pSOLICITUD) :
                new ObjectParameter("PSOLICITUD", typeof(decimal));
    
            var pCUADRILLAParameter = pCUADRILLA.HasValue ?
                new ObjectParameter("PCUADRILLA", pCUADRILLA) :
                new ObjectParameter("PCUADRILLA", typeof(decimal));
    
            var pESTADOParameter = pESTADO != null ?
                new ObjectParameter("PESTADO", pESTADO) :
                new ObjectParameter("PESTADO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GENERA_PLANILLA", pSOLICITUDParameter, pCUADRILLAParameter, pESTADOParameter);
        }
    
        public virtual int GENERA_PRE_PEDIDO(Nullable<decimal> p_IDEXPLOSION)
        {
            var p_IDEXPLOSIONParameter = p_IDEXPLOSION.HasValue ?
                new ObjectParameter("P_IDEXPLOSION", p_IDEXPLOSION) :
                new ObjectParameter("P_IDEXPLOSION", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GENERA_PRE_PEDIDO", p_IDEXPLOSIONParameter);
        }
    
        public virtual int GENERA_PRE_REQUISICION(Nullable<decimal> pR_PROYECTO, Nullable<decimal> pR_BODEGA, Nullable<decimal> pR_MODELO, Nullable<decimal> pR_OBRA)
        {
            var pR_PROYECTOParameter = pR_PROYECTO.HasValue ?
                new ObjectParameter("PR_PROYECTO", pR_PROYECTO) :
                new ObjectParameter("PR_PROYECTO", typeof(decimal));
    
            var pR_BODEGAParameter = pR_BODEGA.HasValue ?
                new ObjectParameter("PR_BODEGA", pR_BODEGA) :
                new ObjectParameter("PR_BODEGA", typeof(decimal));
    
            var pR_MODELOParameter = pR_MODELO.HasValue ?
                new ObjectParameter("PR_MODELO", pR_MODELO) :
                new ObjectParameter("PR_MODELO", typeof(decimal));
    
            var pR_OBRAParameter = pR_OBRA.HasValue ?
                new ObjectParameter("PR_OBRA", pR_OBRA) :
                new ObjectParameter("PR_OBRA", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GENERA_PRE_REQUISICION", pR_PROYECTOParameter, pR_BODEGAParameter, pR_MODELOParameter, pR_OBRAParameter);
        }
    
        public virtual int GENERAR_ADICIONAL(Nullable<decimal> p_COD_PERSONA, Nullable<decimal> p_COD_PLANILLA, Nullable<decimal> pTIPO_PLANILLA, Nullable<decimal> p_COD_COMPANIA)
        {
            var p_COD_PERSONAParameter = p_COD_PERSONA.HasValue ?
                new ObjectParameter("P_COD_PERSONA", p_COD_PERSONA) :
                new ObjectParameter("P_COD_PERSONA", typeof(decimal));
    
            var p_COD_PLANILLAParameter = p_COD_PLANILLA.HasValue ?
                new ObjectParameter("P_COD_PLANILLA", p_COD_PLANILLA) :
                new ObjectParameter("P_COD_PLANILLA", typeof(decimal));
    
            var pTIPO_PLANILLAParameter = pTIPO_PLANILLA.HasValue ?
                new ObjectParameter("PTIPO_PLANILLA", pTIPO_PLANILLA) :
                new ObjectParameter("PTIPO_PLANILLA", typeof(decimal));
    
            var p_COD_COMPANIAParameter = p_COD_COMPANIA.HasValue ?
                new ObjectParameter("P_COD_COMPANIA", p_COD_COMPANIA) :
                new ObjectParameter("P_COD_COMPANIA", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GENERAR_ADICIONAL", p_COD_PERSONAParameter, p_COD_PLANILLAParameter, pTIPO_PLANILLAParameter, p_COD_COMPANIAParameter);
        }
    
        public virtual int GENERA_SALIDA(Nullable<decimal> pSOLICITUD)
        {
            var pSOLICITUDParameter = pSOLICITUD.HasValue ?
                new ObjectParameter("PSOLICITUD", pSOLICITUD) :
                new ObjectParameter("PSOLICITUD", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GENERA_SALIDA", pSOLICITUDParameter);
        }
    
        public virtual int GENERA_SALIDA_MO(Nullable<decimal> pSOLICITUD)
        {
            var pSOLICITUDParameter = pSOLICITUD.HasValue ?
                new ObjectParameter("PSOLICITUD", pSOLICITUD) :
                new ObjectParameter("PSOLICITUD", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GENERA_SALIDA_MO", pSOLICITUDParameter);
        }
    
        public virtual int GENERA_SOBREGIROS(Nullable<decimal> pSOLICITUD)
        {
            var pSOLICITUDParameter = pSOLICITUD.HasValue ?
                new ObjectParameter("PSOLICITUD", pSOLICITUD) :
                new ObjectParameter("PSOLICITUD", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GENERA_SOBREGIROS", pSOLICITUDParameter);
        }
    
        public virtual int GEN_PRE_REQUISICION(Nullable<decimal> pR_PROYECTO, Nullable<decimal> pR_BODEGA, Nullable<decimal> pR_MODELO, Nullable<decimal> pR_OBRA)
        {
            var pR_PROYECTOParameter = pR_PROYECTO.HasValue ?
                new ObjectParameter("PR_PROYECTO", pR_PROYECTO) :
                new ObjectParameter("PR_PROYECTO", typeof(decimal));
    
            var pR_BODEGAParameter = pR_BODEGA.HasValue ?
                new ObjectParameter("PR_BODEGA", pR_BODEGA) :
                new ObjectParameter("PR_BODEGA", typeof(decimal));
    
            var pR_MODELOParameter = pR_MODELO.HasValue ?
                new ObjectParameter("PR_MODELO", pR_MODELO) :
                new ObjectParameter("PR_MODELO", typeof(decimal));
    
            var pR_OBRAParameter = pR_OBRA.HasValue ?
                new ObjectParameter("PR_OBRA", pR_OBRA) :
                new ObjectParameter("PR_OBRA", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GEN_PRE_REQUISICION", pR_PROYECTOParameter, pR_BODEGAParameter, pR_MODELOParameter, pR_OBRAParameter);
        }
    
        public virtual int INGRESA_SCRIPT(Nullable<decimal> pVERSION, string pDESCRIPCION, string pUSUARIO)
        {
            var pVERSIONParameter = pVERSION.HasValue ?
                new ObjectParameter("PVERSION", pVERSION) :
                new ObjectParameter("PVERSION", typeof(decimal));
    
            var pDESCRIPCIONParameter = pDESCRIPCION != null ?
                new ObjectParameter("PDESCRIPCION", pDESCRIPCION) :
                new ObjectParameter("PDESCRIPCION", typeof(string));
    
            var pUSUARIOParameter = pUSUARIO != null ?
                new ObjectParameter("PUSUARIO", pUSUARIO) :
                new ObjectParameter("PUSUARIO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("INGRESA_SCRIPT", pVERSIONParameter, pDESCRIPCIONParameter, pUSUARIOParameter);
        }
    }
}