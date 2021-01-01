<template>
  <div class="text-center">
    <!--      <v-btn-->
    <!--          dark-->
    <!--          color="orange darken-2"-->
    <!--          @click="isOpen = true"-->
    <!--      >-->
    <!--        Open Snackbar-->
    <!--      </v-btn>-->

    <v-snackbar
        v-model="open"
        :timeout="theTimeout"
        :color="color"
    >
      {{ theText }}

      <template v-slot:action="{ attrs }">
        <v-btn
            color="blue"
            text
            v-bind="attrs"
            @click="open = false"
        >
          Close
        </v-btn>
      </template>
    </v-snackbar>
  </div>
</template>

<script lang="ts">
import Component from "vue-class-component";
import {Prop, Vue, Watch} from "vue-property-decorator";

@Component({})
export default class Snackbar extends Vue {

  @Prop({type: Number, default: 2000})
  timeout;
  
  theTimeout = 2000;

  @Prop({type: String, default: ''})
  text;

  theText = '';
  open = false;
  
  color = 'default';

  @Prop({type: Boolean, default: false})
  isOpen;

  @Watch('open')
  watchOpen(newValue) {
    if (!newValue)
      this.$emit('close');
  }

  @Watch('isOpen')
  watchIsOpen(newValue) {
    this.open = !!newValue;
  }

  @Watch('text')
  watchTextProp(newValue) {
    if (newValue)
      this.theText = newValue;
  }
  
  @Watch('timeout')
  watchTimeoutProp(newValue) {
    this.theTimeout = newValue;
  }

  showInfoMessage(text: string) {
    this.theText = text;
    this.color = 'default';
    this.theTimeout = 2000;
    this.open = true;
  }
  
  showErrorMessage(text: string) {
    this.theText = text;
    this.color = 'pink';
    this.theTimeout = 4000;
    this.open = true;
  }
}
</script>

<style scoped>

</style>