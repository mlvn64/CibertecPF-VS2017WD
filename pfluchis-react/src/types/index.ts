// definir las interfaces generales del proyecto

export interface IMesas {
    id: number;
    nombre: string;
    estadoMesa: number;
}

export interface IClientes {
    id: number;
    nombreCompleto: string;
}

export interface IEmpleados {
    id: number;
    nombreCompleto: string;
    
}

export interface ICategorias {
    id: number;
    nombre: string;
    
}

export interface ICartas {
    id: number;
    nombre: string;
    precioUnitario: number;
    
}

export interface IListaDeDetalleTabla {
    idCarta: number;
    categoria: string;
    carta: string;
    precio: number;
    cantidad: number;
    total: number;
    
}

/**
 * Esta interface servira para definir las props base de cada página de nuestro app
 */
export interface IPageBaseProps {
    path?: string;
}