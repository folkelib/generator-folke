import Folke from "bower_components/folke-core/folke";
import Menu from "bower_components/folke-menu/menu";
import Authentication from "bower_components/folke-identity/authentication";
import * as ko from "knockout";

export default function () {
    Menu.addRouteButton(ko.observable('Accueil'), 'home');
    Menu.addSubMenu(ko.observable('Menu')).addRouteButton(ko.observable('About'), 'about');
    Folke.registerComponent('components/home', 'home-page');
    Folke.addRoute('home', 'home-page', 1);
    Folke.registerComponent('components/home', 'about');
    Folke.addRoute('about', 'about');
}
