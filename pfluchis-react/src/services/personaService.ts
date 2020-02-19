import axios from "axios";
import { IEmpleados, IClientes } from "../types";
import { refreshToken } from "./authService";
import { obtenerAuthToken } from "./baseService";

// url base de los servicios web (proyecto VS 2017)
const BASE_URL = "https://localhost:44333/";

export async function obtenerPersonaEmpleados(): Promise<IEmpleados[]> {
    // obtener el resultado de la solicitud en una variable
    const resultado = await axios.get(`${BASE_URL}personas/empleados`
     , {
         headers: {
             // Authorization: `Bearer ${await obtenerAuthToken()}`
             "Access-Control-Allow-Origin": "*"
         }
     }
    );
    // devolver la data obtenida del resultado, casteandola como un arreglo de IProduct
    return resultado.data as IEmpleados[];
}

export async function obtenerPersonaClientes(): Promise<IClientes[]> {
    // obtener el resultado de la solicitud en una variable
    const resultado = await axios.get(`${BASE_URL}personas/clientes`
     , {
         headers: {
             // Authorization: `Bearer ${await obtenerAuthToken()}`
             "Access-Control-Allow-Origin": "*"
         }
     }
    );
    // devolver la data obtenida del resultado, casteandola como un arreglo de IProduct
    return resultado.data as IClientes[];
}