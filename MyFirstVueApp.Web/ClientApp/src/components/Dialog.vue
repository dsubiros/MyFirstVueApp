<template>
<!--  persistent-->
  <v-dialog
      v-model="dialog"
      :max-width="maxWidth"
  >
    <template v-slot:activator="{ on, attrs }">
      <v-btn
          :color="entryButtonColor || 'primary'"
          dark
          v-bind="attrs"
          v-on="on"
          :plain="entryButtonType === 'plain'"
          :depressed="entryButtonType === 'depressed'"
      >
        <v-icon v-if="showEntryButtonIcon">{{ entryButtonIcon }}</v-icon>

        <span v-if="showEntryButtonText">{{ entryButtonIcon }}</span>

      </v-btn>
    </template>
    <v-card>
      <v-card-title class="headline">
        {{title}}
      </v-card-title>
      <v-card-text>{{text}}</v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn
            text
            @click="result = false; dialog = false"
        >
          {{ noButtonLabel }}
        </v-btn>
        <v-btn
            color="error"
            text
            @click="result = true; dialog = false"
        >
          {{ yesButtonLabel }}
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import Component from "vue-class-component";
import {Prop, Vue, Watch} from "vue-property-decorator";

@Component({})
export default class Dialog extends Vue {

  @Prop({type: String, default: ''})
  title;

  @Prop({type: String, default: ''})
  text;

  @Prop({type: Number, default: 350})
  maxWidth;

  @Prop({type: String, default: 'Yes'})
  yesButtonLabel;

  @Prop({type: String, default: 'No'})
  noButtonLabel;

  @Prop({type: String, default: ''})
  entryButtonIcon;

  @Prop({type: String, default: 'Open Dialog'})
  entryButtonText;

  @Prop({type: Boolean, default: false})
  showEntryButtonIcon;

  @Prop({type: Boolean, default: true})
  showEntryButtonText;

  @Prop({type: String, default: 'depressed'})
  entryButtonType;

  @Prop({type: String, default: ''})
  entryButtonColor;

  dialog = false;
  result = false;

  @Watch('dialog')
  watchDialog() {
    if (this.result)
        // this.$emit('result', this.result);
      this.$emit('result');

    this.result = false;
  }

}

// export default {
//   name: "Dialog",
//   props: {
//     isOpen: {
//       type: Boolean,
//       require: true
//     }
//   },
//   data() {
//     return {
//       dialog: false
//     }
//   }
//  
//  
// }
</script>

<style scoped>

</style>