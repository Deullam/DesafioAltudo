<template>
  <v-container class="fill-height">
    <v-row justify="center" align="center">
      <v-col class="px-5">
        <v-card class="mx-5">
          <v-toolbar color="primary" dark>
            <v-toolbar-title>Desafio Altudo</v-toolbar-title>
          </v-toolbar>
          <v-card-text>
            <v-form>
              <v-text-field
                label="Digite a Url do Site"
                type="text"
                v-model="modelPage.url"
              ></v-text-field>
            </v-form>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn
                :loading="loading"
                :disabled="loading"
                color="primary"
                class="ma-2 white--text"
                fab
                elevation-12
                @click="getPageUrl()"
              >
                <v-icon dark> mdi-search-web </v-icon>
              </v-btn>
            </v-card-actions>
          </v-card-text>
        </v-card>

        <PageComponent v-if="openPage" :page="modelPage" />
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import { mapState, mapActions } from "vuex";
import PageComponent from "@/components/pages/Page";

export default {
  name: "Home",
  components: { PageComponent },

  data() {
    return {
      loader: null,
      loading: false,
      openPage: false,
    };
  },

  computed: {
    ...mapState("pages", ["modelPage"]),
  },
  methods: {
    ...mapActions({
      buscarPagina: "pages/buscarUrl",
    }),
    /** Function to get Page by Url */
    async getPageUrl() {
      this.loading = true;
      await this.buscarPagina()
        .then(() => {
          this.openPage = true;
        })
        .catch(() => {})
        .finally(() => {
          this.loading = false;
        });
    },
  },
  watch: {
    /** Function to activate button loader animation  */
    loader() {
      const l = this.loader;
      this[l] = !this[l];

      setTimeout(() => (this[l] = false), 3000);
      this.loader = null;
    },
  },
};
</script>
<style>
</style>