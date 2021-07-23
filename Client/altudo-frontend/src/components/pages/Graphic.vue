<template>
  <v-row justify="center">
    <v-col>
      <v-overlay :z-index="zIndex" :value="overlay">
        <v-card class="mx-auto" color="grey lighten-4" min-width="600">
          <v-card-title>
            <v-row align="start">
              <div class="caption black--text text-uppercase">
                <h2>Gráfico das 10 palavras mais utilizadas:</h2>
              </div>
            </v-row>
            <v-spacer></v-spacer>
            <v-btn
              icon
              class="align-self-start"
              color="blue"
              size="28"
              @click="(overlay = false), $emit('hideOverlay')"
            >
              <v-icon>mdi-arrow-right-thick</v-icon>
            </v-btn>
          </v-card-title>
          <v-sheet color="transparent">
            <v-sparkline
              :labels="wordsG"
              :smooth="1"
              :gradient="['#f72047', '#ffd200', '#1feaea']"
              :line-width="3"
              :value="values"
              auto-draw
              stroke-linecap="round"
            >
              <template v-slot:label="item">
                {{ item.value }}
              </template>
            </v-sparkline>
          </v-sheet>
        </v-card>
      </v-overlay>
    </v-col>
  </v-row>
</template>

<script>
import { mapState } from "vuex";
export default {
  name: "Graphic",
  data() {
    return {
      overlay: true,
      zIndex: 0,
      values: [],
      wordsG: [],
    };
  },

  computed: {
    ...mapState("pages", ["modelPage"]),
  },
  mounted() {
    this.modelPage.mostUsedWords.forEach((element) => {
      this.wordsG.push(element.word);
      this.values.push(element.occurrences);
    });
  },
};
</script>

<style scoped>
</style>