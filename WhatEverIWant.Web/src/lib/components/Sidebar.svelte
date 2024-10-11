<script lang="ts">
	export let items: { name: string; link: string }[];
</script>

<aside class="bg-gray-700 text-white w-64 p-4 hidden md:block">
	<nav>
		<ul>
			{#each items as item}
				<li class="mb-2">
					<a href={item.link} class="block p-2 hover:bg-gray-600 rounded">{item.name}</a>
				</li>
			{/each}
		</ul>
	</nav>
</aside>
