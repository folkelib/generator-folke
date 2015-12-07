/// <amd-dependency path="text!./about.html" />
import * as Service from "services/services";
import * as Ko from "knockout";

export class AboutViewModel {
    constructor(params?: { [index: string]: string; }) {
    }

    dispose() { }
}

export var viewModel = AboutViewModel;