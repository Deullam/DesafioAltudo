<template>
  <v-container fluid>
    <v-row v-show="page.mostUsedWords.length > 0">
      <v-col
        class="d-flex justify-lg-center align-lg-left"
        cols="12"
        sm="8"
        lg="6"
      >
        <v-card sty>
          <v-list-item two-line>
            <v-list-item-content>
              <v-list-item-title class="text-h5">
                As 10 palavras que mais apareceram:
              </v-list-item-title>
            </v-list-item-content>
          </v-list-item>

          <v-list min-height="600" class="transparent">
            <v-list-item
              v-for="(item, index) in page.mostUsedWords"
              :key="index"
            >
              <v-list-item-title>{{ item.word }}</v-list-item-title>

              <v-list-item-subtitle class="text-right">
                {{ item.occurrences }}
              </v-list-item-subtitle>
            </v-list-item>
          </v-list>
          <v-divider></v-divider>
          <v-card-actions>
            <v-btn
              text
              color="blue"
              @click="isGraphic = !isGraphic"
              @hideOverlay="isGraphic = !isGraphic"
            >
              Mostrar Gráfico</v-btn
            >
          </v-card-actions>
        </v-card>
      </v-col>

      <v-col cols="12" sm="4" lg="6">
        <v-row>
          <v-col
            v-for="(image, indexImages) in getImages"
            :key="indexImages"
            sm="6"
          >
            <v-img
              :src="image"
              max-height="150"
              max-width="250"
              aspect-ratio="1"
              class="grey lighten-2"
            >
              <template v-slot:placeholder>
                <v-row class="fill-height ma-0" align="center" justify="center">
                  <v-progress-circular
                    indeterminate
                    color="grey lighten-5"
                  ></v-progress-circular>
                </v-row>
              </template>
            </v-img>
          </v-col>
        </v-row>
      </v-col>

      <v-col cols="12">
        <v-row>
          <v-col
            v-for="(image, index) in getImagesTotal"
            :key="index"
            class="d-flex child-flex"
            cols="3"
          >
            <v-img
              :src="image"
              aspect-ratio="1"
              class="grey lighten-2"
              max-height="150"
              max-width="250"
            >
              <template v-slot:placeholder>
                <v-row class="fill-height ma-0" align="center" justify="center">
                  <v-progress-circular
                    indeterminate
                    color="grey lighten-5"
                  ></v-progress-circular>
                </v-row>
              </template>
            </v-img>
          </v-col>
        </v-row>
      </v-col>
      <GraficoComponent v-if="isGraphic" />
    </v-row>
  </v-container>
</template>

<script>
import GraficoComponent from "@/components/pages/Graphic";
export default {
  name: "Page",

  props: {
    page: {
      type: Object,
      required: true,
    },
  },
  components: {
    GraficoComponent,
  },
  data() {
    return {
      isGraphic: false,
    };
  },
  computed: {
    /** Function used to place images next to the table  */
    getImages() {
      return this.page.linksImages.filter((search, index) => {
        return index < 8;
      });
    },
    /**Function used to place other images under the table  */
    getImagesTotal() {
      return this.page.linksImages.filter((search, index) => {
        return index > 8;
      });
    },
  },
};
</script>

<style>
</style>
