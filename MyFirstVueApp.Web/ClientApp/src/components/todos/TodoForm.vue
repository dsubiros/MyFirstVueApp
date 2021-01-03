<template>
<!--  persistent-->
<!--  v-model="isOpen"-->
<!--  :value="isOpen"-->
<!--  @input="$emit('input', $event)"-->
  <v-dialog
      v-model="isOpen"
      :max-width="maxWidth"
  >
<!--    <template v-slot:activator="{ on, attrs }">-->
<!--      <v-btn-->
<!--          :color="entryButtonColor || 'primary'"-->
<!--          dark-->
<!--          v-bind="attrs"-->
<!--          v-on="on"-->
<!--          :plain="entryButtonType === 'plain'"-->
<!--          :depressed="entryButtonType === 'depressed'"-->
<!--          :icon="entryButtonIsIcon"-->
<!--      >-->
<!--        <v-icon v-if="showEntryButtonIcon">{{ entryButtonIcon }}</v-icon>-->
<!--        <span v-if="showEntryButtonText">{{ entryButtonIcon }}</span>-->
<!--      </v-btn>-->
<!--    </template>-->

<!--    <v-btn color="red" @click.native="$emit('input', false)">Close</v-btn>-->

<!--    v-if="item"-->
    <v-card :loading="isLoading">
      <v-card-title>
        <span class="headline">{{ title }}</span>
      </v-card-title>

      <v-card-text>
        <v-container>
          <div>selectedItem: {{item}}</div>
          <v-row @keydown.enter="saveItemOffline()">
            <v-col
                cols="12"
                sm="6"
                md="4"
            >
              <v-text-field
                  v-model="item.text"
                  label="Dessert name"
              ></v-text-field>
            </v-col>
            <v-col
                cols="12"
                sm="6"
                md="4"
            >
              <v-text-field
                  v-model="item.enabled"
                  label="Calories"
              ></v-text-field>
            </v-col>
          </v-row>
        </v-container>
      </v-card-text>

      <v-card-actions>
        <v-spacer></v-spacer>
<!--        @click="close"-->
        <v-btn
            color="blue darken-1"
            text
            @click="isOpen = false"
        >
          Cancel
        </v-btn>
<!--        @click="save"-->
<!--        @click="isOpen = false"-->
        <v-btn
            color="blue darken-1"
            text
            @click="saveItemOffline()"
        >
          Save
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import Component from "vue-class-component";
import {Emit, Prop, Vue, Watch} from "vue-property-decorator";
import {Todo} from "@/components/todos/TodoList.vue";

@Component({})
export default class TodoForm extends Vue {

  @Prop()
  item: Todo;
  
  @Prop({type: String, default: ''})
  title: string;

  @Prop({type: Number, default: 350})
  maxWidth: number;
    
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

  @Prop({type: String, default: 'icon'})
  entryButtonType;

  @Prop({type: Boolean, default: false})
  entryButtonIsIcon: boolean;

  @Prop({type: String, default: ''})
  entryButtonColor;

  result = false;

  isLoading = false;

  // @Prop({type: Boolean, default: false})
  // isOpen = false;

  // open = false;

  @Prop({type: Boolean, default: false})
  value;
  
  set isOpen(value: boolean) {
    this.$emit('input', value);
  }
  
  get isOpen() {
    return this.value;
  }

  @Emit()
  saveItemOffline() {
    this.$emit('save-item-offline', this.item);
  }

//   show: {
//     get () {
//       return this.value
//     },
//    set (value) {
//       this.$emit('input', value)
//    }
// }

  // @Watch('dialog')
  // watchDialog() {
  //   if (this.result)
  //       // this.$emit('result', this.result);
  //     this.$emit('result', this.item);
  //   this.result = false;
  // }

  // @Watch('isOpen')
  // watchIsOpen(newValue: boolean) {
  //   // debugger
  //   this.open = newValue;
  //  
  // }

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