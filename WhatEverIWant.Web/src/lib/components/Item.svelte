<script lang="ts">
	export let item: { name: string; description: string; id: string };
</script>

<div class="bg-white p-4 rounded shadow">
	<h2 class="text-lg font-bold">{item.name}</h2>
	<p>{item.description}</p>
	<a href={`/details/${item.id}`} class="text-blue-500">Details</a>
</div>
