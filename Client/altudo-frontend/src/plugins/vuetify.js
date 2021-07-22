import Vue from 'vue';
import Vuetify from 'vuetify/lib/framework';
//import colors from "vuetify/es5/util/colors";
import pt from 'vuetify/lib/locale/pt';
import 'roboto-fontface/css/roboto/roboto-fontface.css'
import '@mdi/font/css/materialdesignicons.css'

Vue.use(Vuetify);

export default new Vuetify({
  lang: {
    locales: { pt },
    current: 'pt',
  },
  options: {
    customProperties: true
  },
  themes: {
    light: {
      primary: '#44BBA4',
      secondary: '#424242',
      accent: '#82B1FF',
      error: '#FF5252',
      info: '#2196F3',
      success: '#4CAF50',
      warning: '#FFC107'
    }
  }
});
