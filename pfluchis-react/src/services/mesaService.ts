import axios from "axios";
import { IMesas } from "../types";
import { refreshToken } from "./authService";
import { obtenerAuthToken } from "./baseService";
//import { refreshToken } from "./authService";
//import { obtenerAuthToken } from "./baseService";

// url base de los servicios web (proyecto VS 2017)
const BASE_URL = "https://localhost:44333/";

export async function obtenerTodos(): Promise<IMesas[]> {
    // obtener el resultado de la solicitud en una variable
    const resultado = await axios.get(`${BASE_URL}mesas/ListarTodos`
     , {
         headers: {
              Authorization: `Bearer ${await obtenerAuthToken()}`
             //"Access-Control-Allow-Origin": "*"
         }
     }
    );
    // devolver la data obtenida del resultado, casteandola como un arreglo de IProduct
    return resultado.data as IMesas[];
}