import { BaseOut } from "./BaseOut";

export class BaseGetListOut<T> extends BaseOut {
    public listResult: Array<T> = [];
}