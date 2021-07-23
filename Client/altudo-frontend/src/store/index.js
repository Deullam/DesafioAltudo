import Vue from 'vue'
import Vuex from 'vuex'
import pages from './modules/pages'

Vue.use(Vuex)
const store = new Vuex.Store({
  modules: {
    pages
  },

})
export default store
