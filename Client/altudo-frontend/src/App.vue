<template>
  <v-app>
    <v-main>
      <router-view />
    </v-main>

    <v-footer app padless>
      <Footer></Footer>
    </v-footer>
  </v-app>
</template>

<script>
import Footer from "@/components/Footer";
export default {
  name: "App",
  components: { Footer },
};
</script>
