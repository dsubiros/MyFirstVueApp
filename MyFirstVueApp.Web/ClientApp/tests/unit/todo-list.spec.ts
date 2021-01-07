import {shallowMount} from "@vue/test-utils";
import TodoList from "@/components/todos/TodoList.vue";

debugger
let wrapper: any = null;

beforeEach(() => {
    wrapper = shallowMount(TodoList, {
        propsData: {
            todos: [], 
            selectedItem: {},
            selectedItemIndex: -1,
        }
    });
})

afterEach(() => {
    wrapper.destroy();
})

describe("TodoList", () => {
    it("renders the header", () => {
        const header = wrapper.findAll('h1');
        expect(header.length).toBe(1);
    });
        
    it("renders the table", () => {
        const table = wrapper.findAll('tr');
        expect(table.length).toBeGreaterThan(1);
        
    });

    // it("renders the active stars", () => {
    //     const active = wrapper.findAll('li.star.active');
    //
    //     expect(active.length).toBe(2);
    // });
    //
    // it("renders a summary", () => {
    //     const summary = wrapper.find('.summary');
    //
    //     expect(summary.text()).toBe("2 of 5");
    // });
})

// import { shallowMount } from "@vue/test-utils";
// import HelloWorld from "@/components/HelloWorld.vue";
//
// describe("HelloWorld.vue", () => {
//   it("renders props.msg when passed", () => {
//     const msg = "new message";
//     const wrapper = shallowMount(HelloWorld, {
//       propsData: { msg }
//     });
//     expect(wrapper.text()).toMatch(msg);
//   });
// });
