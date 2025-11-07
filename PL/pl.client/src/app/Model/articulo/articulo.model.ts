import { ArticuloTienda } from '../articulo-tienda/articulo-tienda.model';

export interface Articulo {
  IdArticulo: number;
  ArticuloTienda?: ArticuloTienda | null;   
  Codigo: string;
  Descripcion: string;
  Precio: number;                         
  Imagen?: Uint8Array | null;            
  Stock: number;
  Articulos?: any[];
}
