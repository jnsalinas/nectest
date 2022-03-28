import { Quote } from "./Quote";

export class Cryptocurrency{
    id?: number;
    symbol?: string;
    name?: string;
    listQuote: Quote[] = [];
    circulatingSupply?: number;
}