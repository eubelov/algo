namespace Algorithms.LeetCode.Graphs;

/// <summary>
/// https://leetcode.com/problems/course-schedule/submissions/
/// </summary>
public static class CourseSchedule
{
    private static readonly List<int> EmptyList = new();

    public static bool CanFinish(int numCourses, int[][] prerequisites)
    {
        if (prerequisites.Length == 0)
        {
            return true;
        }

        Dictionary<int, List<int>> adjList = new();
        for (var i = 0; i < numCourses; i++)
        {
            adjList[i] = new();
        }

        foreach (var pair in prerequisites)
        {
            adjList[pair[0]].Add(pair[1]);
        }

        foreach (var node in adjList)
        {
            var canComplete = Explore(adjList, node.Key, new());
            if (!canComplete)
            {
                return false;
            }

            adjList[node.Key] = EmptyList;
        }

        return true;
    }

    private static bool Explore(Dictionary<int, List<int>> adjList, int start, HashSet<int> visited)
    {
        if (adjList[start].Count == 0)
        {
            return true;
        }

        if (visited.Contains(start))
        {
            return false;
        }

        visited.Add(start);
        foreach (var n in adjList[start])
        {
            var canComplete = Explore(adjList, n, visited);
            if (!canComplete)
            {
                return false;
            }
        }

        visited.Remove(start);

        return true;
    }
}
