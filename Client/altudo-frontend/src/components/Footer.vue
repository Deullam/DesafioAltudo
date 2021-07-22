<template>
<v-container>

  <v-footer padless>
    <v-col class="text-center" cols="12">
      {{ new Date().getFullYear() }} — <strong>Deullam Justi</strong>
    </v-col>
  </v-footer>

</v-container>
</template>

<script>
export default {
  name: "footer",
};
</script>