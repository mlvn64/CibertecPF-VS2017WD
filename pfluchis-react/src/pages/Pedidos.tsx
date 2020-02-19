import React, { useState, useEffect } from "react";
import { IListaDeDetalleTabla,ICartas, ICategorias, IEmpleados, IClientes, IPageBaseProps } from "../types";
import { Title } from "../components/global/Title";
//import { DescripcionCantidad } from "../components/global/DescripcionCantidad";
//import { TablaProductos } from "../components/tablaProductos/TablaProductos";
import { obtenerPersonaEmpleados, obtenerPersonaClientes } from "../services/personaService";
import { obtenerCategorias, obtenerCartasPorCategoria } from "../services/cartaService";
import './Style.css';
import loading from './loading.svg';
import { Link } from "@reach/router";


export function Pedidos(props: IPageBaseProps) {
    
    // utilizar el state para manjear una variable data
    const [empleadoData, setEmpleadoData] = useState<IEmpleados[]>([]);
    const [categoriaData, setCategoriaData] = useState<ICategorias[]>([]);
    const [cartaData, setCartaData] = useState<ICartas[]>([]);
    const [ListaDetalleTablaData, setListaDetalleTablaData] = useState<IListaDeDetalleTabla[]>([]);
    const id = 1;
    const nombreCategoria = "";

    const [cargando, setCargando] = useState<boolean>(true);

    async function cargarEmpleados() {
        var empleados = await obtenerPersonaEmpleados();
        setEmpleadoData(empleados);
    //     // una vez que tengamos respuesta del servicio, ocultar el indicador de cargando
        setCargando(false);
     }

     async function cargarCategorias() {
        var categorias = await obtenerCategorias();
        setCategoriaData(categorias);
    //     // una vez que tengamos respuesta del servicio, ocultar el indicador de cargando
        setCargando(false);
     }
     
     async function cargarCartasPorCategoria(id : number){
        var Cartas = await obtenerCartasPorCategoria(id);
        setCartaData(Cartas)

        setCargando(false);
    }
    async function refrescarCartasEnElDetalle(id : number, nombreCategoria : string){
        var Cartas = await obtenerCartasPorCategoria(id);
        nombreCategoria = nombreCategoria;
        setCartaData(Cartas)      


        setCargando(false);
    }
    async function refrescarCartasYCategoriasEnLaTabla(id : number,nombreCarta: string, precioUnitario : number, nombreCategoria : string){
        
        
        //setListaDetalleTablaData(id,nombreCategoria,nombreCarta,precioUnitario,1,2)
        setCargando(false);
    }

    // definir un efecto para cuando el componente cargue por primera vez
    useEffect(() => {
        // simular un servicio lento
        // setTimeout(() => {
            cargarEmpleados();
            cargarCategorias();
            cargarCartasPorCategoria(id);
        // }, 500);

    }, [])

    

    // const descripcionCantidad = `Hay ${mesasData.length} mesas registradas`;
    // console.info("HOL   ");
    // console.info(mesasData);

    // mostrar el indicador de cargando
    if (cargando) {
        return <div className="d-flex justify-content-center">
            <img src={loading}></img>
        </div>
    }

    // const options = [
    //     { value: 'chocolate', label: 'Chocolate' },
    //     { value: 'strawberry', label: 'Strawberry' },
    //     { value: 'vanilla', label: 'Vanilla' },
    //   ];
    
    return <div>
        <Title texto="Pedidos"></Title>
        <br/>
        <div className="col-12">
        <div className="form-group row">
            <label className="col-2 col-form-label">Vendedor</label>
            <div className="col-6">
            <select className="custom-select" id="inputGroupSelect01">
                <option selected>Insertar el Vendedor..</option>
                {
                    empleadoData.map(
                        empleados =>(
                            <option>{empleados.nombreCompleto}</option>
                        )
                    )
                }
                                
            </select>
            </div>
        </div>
        </div>
        <br />
        <div className="row col-12">
            <div className="col-3">
                {
                    categoriaData.map(
                        categorias =>(
                            <div v-for="listaCategorias in ListaDeCategorias" className="card bg-info border-info text-center mb-1 pedidoCategoriaTableCard">
                            <a onClick={() => refrescarCartasEnElDetalle(categorias.id,categorias.nombre)} href="#" className="btn btn-light text-center">
                                <div className="card-body">
                                <h2 className="card-title">{categorias.nombre}</h2>
                                </div>
                            </a>
                        </div>
                        )
                    )
                }
            </div>
            <div className="col-6">
                <div className="container">
                    <div className="row col-12">
                        {
                            cartaData.map(
                                cartas =>(
                                    <div v-for="listaCartas in ListaDeCartas" className="card col-3 text-center text-white bg-info position-relative">
                                    <a onClick={() => refrescarCartasYCategoriasEnLaTabla(cartas.id, cartas.nombre, cartas.precioUnitario, nombreCategoria )} href="#" className="nounderline stretched-link text-center pedidoListaCartasTableCard">
                                        <div className="card-body pedidoListaCartasNombreTableCard" >
                                        <p className="card-text">{cartas.nombre}</p>
                                        </div>
                                    </a>
                        </div>
                                )
                            )
                        }
                    </div>
                </div>
            </div>
            <div className="col-3">
                <div className="pedidoListaCartasNombreTableCard" v-for="">
                    <div className="card text-center text-white bg-dark">
                        <div className="card-body">
                            <label className="card-text font-weight-bold pedidoTablePagos">PAGO TOTAL</label><br />
                            <label className="card-text font-weight-bold pedidoTablePagos">total</label>
                            <br /><br />
                            <button className="btn btn-danger" >Pedir</button>
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div className="col-12">
            <div className="table-responsive-sm">
                <table className="table table-sm table-bordered table-hover">
                    <thead className="thead-dark">
                        <tr>
                            <th>Categoria</th>
                            <th>Producto</th>
                            <th>Precio</th>
                            <th>Cantidad</th>
                            <th>total</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="detalle in listaDeDetalles">
                            <td>detallecategoria</td>
                            <td>detallecarta</td>
                            <td>detalleprecio</td>
                            <td>
                                <input type="number" v-model="detalle.cantidad" />
                            </td>
                            <td>detalletotal</td>
                            <td>                                
                                <a href="#"><i className="fas fa-trash-alt fa-2x  eliminarDetalle" ></i></a>
                                <button className="btn btn-link btn-sm">Borrar</button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
 
    </div>
}

