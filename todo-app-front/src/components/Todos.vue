<template>
    <section class="todos-empty-text" v-if="todos.length == 0">{{ message }}</section>
    <section v-else>
        <Todo class="todo-item"
            v-for="todo in todos"
            :title="todo.title"
            :description="todo.description"
            :date="todo.date"
            :isDone="todo.isDone"
            :editable="editable"
            @emitDeleteTodo="$emit('deleteTodoFromDb', todo.id)"
            @emitEditTodo="(todoData) => $emit('emitTriggerEditTodo', todo.id, todoData)"
            @emitDoneTodo="(todoDone) => $emit('doneTodoInDb', todo.id)"
            />
    </section>
</template>

<script>
    import Todo from './Todo.vue';

    export default {
        props: ['todos', 'editable', 'message'],
        components: {
            Todo
        },
    }
</script>

<style lang="css" scoped>

.todo-item {
    display: flex;
    justify-content: center;
    width: 90%;
}

</style>