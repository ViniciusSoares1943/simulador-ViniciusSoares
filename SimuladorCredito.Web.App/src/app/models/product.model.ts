import { PersonType } from "../enums/person-type.enum";

export interface Product{
    name: string;
    description: string;
    createdAt: Date;
    personType: PersonType;
    productId: number;
}