import { Municipio } from '../municipio/municipio.model';

export interface Colonia {
  IdColonia: number;
  Nombre: string;
  CodigoPostal: string;
  Municipio: Municipio;
  Colonias: any[];
}
