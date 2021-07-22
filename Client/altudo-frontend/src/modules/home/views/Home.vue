<template>
  <v-container fill-height>
    <v-layout justify-center align-center>
      <v-flex px-5>
        <v-card mx-5>
          <v-toolbar color="primary" dark>
            <v-toolbar-title>Desafio Altudo</v-toolbar-title>
          </v-toolbar>
          <v-card-text>
            <v-form>
              <v-text-field
                name="url"
                label="Digite a Url do Site"
                type="text"
                v-model="url"
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

        <v-row v-show="mostUsedWords.length > 0"> 
          <v-col justify-center align-left>
            <v-card max-width="500">
              <v-list-item two-line>
                <v-list-item-content>
                  <v-list-item-title class="text-h5">
                    As 10 palavras que mais apareceram:
                  </v-list-item-title>
                </v-list-item-content>
              </v-list-item>

              <v-list min-height="500" class="transparent">
                <v-list-item v-for="item in mostUsedWords" :key="item">
                  <v-list-item-title>{{ item.word }}</v-list-item-title>

                  <v-list-item-subtitle class="text-right">
                    {{ item.occurrences }}
                  </v-list-item-subtitle>
                </v-list-item>
              </v-list>
              <v-divider></v-divider>
              <v-card-actions>
                <v-btn text> Mostrar Gráfico </v-btn>
              </v-card-actions>
            </v-card>
          </v-col>

          <v-row>
            <v-col
              v-for="image in LinksImages"
              :key="image"
              class="d-flex child-flex"
              cols="4"
            >
              <v-img
                :src="image"
                max-height="150"
                max-width="250"
                aspect-ratio="1"
                class="grey lighten-2"
              >
                <template v-slot:placeholder>
                  <v-row
                    class="fill-height ma-0"
                    align="center"
                    justify="center"
                  >
                    <v-progress-circular
                      indeterminate
                      color="grey lighten-5"
                    ></v-progress-circular>
                  </v-row>
                </template>
              </v-img>
            </v-col>
          </v-row>
        </v-row>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import { mapActions } from "vuex";
import PageService from "@/services/Page.js";
//import PageComponent from "@/components/pages/Page";

export default {
  name: "Home",
  //components: { PageComponent },
  data() {
    return {
      loader: null,
      loading: false,
      linkurl: "",
      text: "",
      Page: {
        Url: "",
        LinksImages: [],
        WordsList: "",
        MostUsedWords: [],
      },
      PageNew: {
        Url: "",
        LinksImages: [],
        WordsList: "",
        MostUsedWords: [],
      },
      Url: "www.google.com",
      LinksImages: [
        "https://fotospublicas.com/wp-content/uploads/2021/07/51322634562_5132fccffb_k.jpg",
        "https://fotospublicas.com/wp-content/uploads/2021/07/51316607969_44d1322ed8_k.jpg",
        "https://fotospublicas.com/wp-content/uploads/2021/07/51315544066_1b29541ff8_k.jpg",
        "https://fotospublicas.com/wp-content/uploads/2021/07/51315703245_08d3f20f53_k.jpg",
        "https://fotospublicas.com/wp-content/uploads/2021/07/51302675493_efecae35e6_k.jpg",
        "https://fotospublicas.com/wp-content/uploads/2021/07/51300872920_2f2d8bb3d5_k.jpg",
        "https://fotospublicas.com/wp-content/uploads/2021/07/26034_Perseverance-Looks-Out-Over-Seitah.jpeg",
        "https://fotospublicas.com/wp-content/uploads/2021/07/e5dkyaxxoaecnww.jpeg",
        "https://fotospublicas.com/wp-content/uploads/2021/07/51295459495_ad3a418838_k.jpg",
        "https://fotospublicas.com/wp-content/uploads/2021/07/51294271863_5b4dd2fc1a_k.jpg",
      ],
      wordsList: "",
      mostUsedWords: [],
    };
  },
  methods: {
    ...mapActions({
      buscarPagina: "pages/buscarUrl",
    }),
    async getPageUrl() {
      try {
        (this.loading = true), (this.Page.Url = this.url);
        const item = this.Page;

        let response = await PageService.getPage(item).then(
          (response) => (this.Page = response.data)
        );
        this.PageNew = response;

        console.log(response);
        console.log(response.linksImages);
        console.log(this.PageNew.url);
        console.log(this.PageNew.linksImages);
        console.log(this.PageNew.mostUsedWords);
        console.log(this.PageNew.wordsList);
        this.LinksImages = this.PageNew.linksImages;
        this.mostUsedWords = this.PageNew.mostUsedWords;
      } catch (error) {
        alert(error);
      } finally {
        this.loading = false;
      }
    },
  },
  watch: {
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