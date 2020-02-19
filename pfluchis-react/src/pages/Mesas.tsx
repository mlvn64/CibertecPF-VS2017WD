import React, { useState, useEffect } from "react";
import { IMesas, IPageBaseProps} from "../types";
import { Title } from "../components/global/Title";
import { obtenerTodos } from "../services/mesaService";
import { Link } from "@reach/router";
import './Style.css';
import loading from './loading.svg';

// const list = [
//     {
//         Id: 1,
//         Nombre: 'Mesa 1',
//         EstadoMesa: 'Libre'
//     },
//     {
//         Id: 2,
//         Nombre: 'Mesa 2',
//         EstadoMesa: 'Ocupado'
//     },
//     {
//         Id: 3,
//         Nombre: 'Mesa 1',
//         EstadoMesa: 'Libre'
//     },
//     {
//         Id: 4,
//         Nombre: 'Mesa 2',
//         EstadoMesa: 'Ocupado'
//     }
// ]


export function Mesas(props: IPageBaseProps){
    // utilizar el state para manjear una variable data
    const [mesasData, setMesasData] = useState<IMesas[]>([]);
    const [cargando, setCargando] = useState<boolean>(true);

    async function cargarMesas() {
        var mesas = await obtenerTodos();
        setMesasData(mesas);

    //     // una vez que tengamos respuesta del servicio, ocultar el indicador de cargando
        setCargando(false);
     }

    // definir un efecto para cuando el componente cargue por primera vez
    useEffect(() => {
        // simular un servicio lento
        // setTimeout(() => {
            cargarMesas();
        // }, 500);

    }, [])

    // const descripcionCantidad = `Hay ${mesasData.length} mesas registradas`;
    // console.info("HOL   ");
    // console.info(mesasData);

    //<a  href="./Pedidos.tsx"  className= {`btn btn-primary ${mesa.estadoMesa}`}>{ mesa.estadoMesa }</a>

    // mostrar el indicador de cargando
    if (cargando) {
        return <div className="d-flex justify-content-center">
            <img src={loading}></img>
        </div>
    }
    
    return <div>
        <Title texto="Mesas"></Title>
        {/* <h1>{descripcionCantidad}</h1> */}
        <br/>
        <div className="row col-12">
           {              
                mesasData.map(   
                    mesa => (
                        <div key={mesa.id} className="col-4 tableCard">

                            <div className="card text-center text-white bg-info">
                                <div className="card-body">
                                    <h5 className="card-title">{ mesa.nombre }</h5>                        
                                    
                                    <Link to="/pedidos/insert" className={`btn btn-primary ${mesa.estadoMesa}`}>{ mesa.estadoMesa }</Link>
                                </div> 
                            </div>     

                        </div>
                    )
                )           
            }
            </div> 
 
    </div>

}