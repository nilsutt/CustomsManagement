export interface Shipment {
  id: number;
  importerExporterName: string;
  productType: string;
  declaredValue: number;
  tax: number;
  status: string;
  createdDate?: Date;
}
