import axios from "axios";
import { ICategorias, ICartas } from "../types";
import { refreshToken } from "./authService";
import { obtenerAuthToken } from "./baseService";

// url base de los servicios web (proyecto VS 2017)
const BASE_URL = "https://localhost:44333/";

export async function obtenerCategorias(): Promise<ICategorias[]> {
    // obtener el resultado de la solicitud en una variable
    const resultado = await axios.get(`${BASE_URL}cartas/Categorias`
     , {
         headers: {
             // Authorization: `Bearer ${await obtenerAuthToken()}`
             "Access-Control-Allow-Origin": "*"
         }
     }
    );
    // devolver la data obtenida del resultado, casteandola como un arreglo de IProduct
    return resultado.data as ICategorias[];
}
//const id =1;
export async function obtenerCartasPorCategoria(id: number): Promise<ICartas[]> {
    const resultado = await axios.get(`${BASE_URL}cartas/CartasPorCategoria/${id}`)
    // https://localhost:44361/products/3
    return resultado.data as ICartas[];
}