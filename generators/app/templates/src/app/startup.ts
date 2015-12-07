/// <amd-dependency path="bower_components/folke-core/default-components" />
/// <amd-dependency path="bower_components/folke-ko-localization/folke-ko-localization" />
/// <amd-dependency path="bower_components/folke-menu/default-menu" />
import application from "bower_components/folke-core/folke";
import home from "components/home/home";
import identity from "bower_components/folke-identity/identity";

home();
identity('bower_components/folke-identity');
application.start();
