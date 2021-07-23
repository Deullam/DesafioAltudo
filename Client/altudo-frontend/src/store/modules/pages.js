import PageService from '@/services/Page.js'

const state = {
  modelPage: {
    url: 'https://fotospublicas.com/editoria/tecnologia/',
    linksImages: [],
    mostUsedWords: [],
  },
};

const getters = {

};

const mutations = {
  updatePage(state, payload) {
    state.modelPage = payload
  }
};

const actions = {
  /** Function to get page by URL making call to API service */
  async buscarUrl({ commit, state }) {
    let { data } = await PageService.getPage(state.modelPage)
    commit('updatePage', data)
  }

};

export default {
  namespaced: true,
  state,
  getters,
  mutations,
  actions
};

