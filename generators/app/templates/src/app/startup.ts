import application from "bower_components/folke-core/folke";
import home from "components/home/home";
import * as identity from "bower_components/folke-identity/identity";
import * as defaultMenu from "bower_components/folke-menu/default-menu";
import * as localization from "bower_components/folke-ko-localization/folke-ko-localization";
import * as defaultComponents from "bower_components/folke-core/default-components";

localization.register();
defaultComponents.register();
defaultMenu.register();
identity.register('bower_components/folke-identity');
identity.registerMenu('bower_components/folke-identity');
identity.registerAdministration('bower_components/folke-identity', 'Administrator');
identity.registerAdministrationMenu('Administrator');

home();
application.start();
