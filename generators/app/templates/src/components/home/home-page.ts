/// <amd-dependency path="text!./home-page.html" />
import * as Service from "services/services";
import * as Ko from "knockout";

export class HomeViewModel {
    public message = Ko.observable("message");

    constructor(params?: { [index: string]: string; }) {
    }

    dispose() {}
}

export var viewModel = HomeViewModel;