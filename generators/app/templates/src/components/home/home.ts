import Folke from "bower_components/folke-core/folke";
import Menu from "bower_components/folke-menu/menu";
import Authentication from "bower_components/folke-identity/authentication";
import * as ko from "knockout";

export default function () {
    Menu.addRouteButton('Accueil', 'home');
    Menu.addButton('Se connecter', () => Folke.showPopin('identity-login').then(() => Folke.hidePopin()), 0, ko.computed(() => !Authentication.logged()));
    Menu.addButton('Se déconnecter', Authentication.logout, 0, Authentication.logged);
    Menu.addSubMenu('Menu').addRouteButton('About', 'about');
    Folke.registerComponent('components/home', 'home-page');
    Folke.addRoute('home', 'home-page', 1);
    Folke.registerComponent('components/home', 'about');
    Folke.addRoute('about', 'about');
}
