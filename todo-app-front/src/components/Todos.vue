<template>
    <main>
        <section v-if="todos.length == 0">Ups! niczego tutaj nie ma :/ Dodaj nowe zadanie</section>
        <section v-if="isAddingTodo">
            <template v-if="isAddingTodo">
                <input v-model="editableTitle" class="edit-input" />
                <textarea v-model="editableDescription" class="edit-textarea"></textarea>
                <button class="save-btn" @click="saveChanges">Zapisz</button>
                <button class="cancel-btn" @click="cancelAdd">Anuluj</button>
            </template>
        </section>
        <section v-else>
        <Todo v-for="todo in todos"
            :title="todo.title"
            :description="todo.description"
            :date="todo.date"
            @emitDeleteTodo="$emit('deleteTodoFromDb', todo.id)"
            @emitUpdateTodo="(todoData) => $emit('editTodoInDb', todo.id, todoData)"></Todo>
        </section>
    </main>
</template>

<script>
    import Todo from './Todo.vue';

    export default {
        data() {
            return {
                isAddingTodo: false,
                editableTitle: "",
                editableDescription: ""
            }
        },
        props: ['todos'],
        components: {
            Todo
        },
        methods: {
            triggerAddTodo() {
                this.isAddingTodo = true
                console.log(this.isAddingTodo)
            },
            saveChanges() {
                this.$emit("saveTodoInDb", this.editableTitle, this.editableDescription)
                this.isAddingTodo = false
            }
            ,
            cancelAdd() {
                this.isAddingTodo = false
            }
        }
    }
</script>

<style lang="css" scoped>

main {
    padding: 20px;
}

</style>