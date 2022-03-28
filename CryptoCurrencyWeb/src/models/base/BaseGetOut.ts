import { BaseOut } from "./BaseOut";

export class BaseGetOut<T> extends BaseOut {
    public entity = {} as T;
}